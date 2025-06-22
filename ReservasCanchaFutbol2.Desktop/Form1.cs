using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservasCanchaFutbol2.Desktop.Models;


namespace ReservasCanchaFutbol.UI
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "http://localhost:7259/api/reserva"; // Cambiar puerto si es necesario

        public Form1()
        {
            InitializeComponent();

            // 1) Crea un handler que acepte el certificado (solo en desarrollo)
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            // 2) Inicializa HttpClient con el handler
            _httpClient = new HttpClient(handler)
            {
                // 3) Apunta al puerto correcto
                BaseAddress = new Uri("https://localhost:7259/")
            };

            // 4) Liga el Load
            this.Load += Form1_Load;

        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarReservas();
            await CargarCanchas();
        }


        // 1) Métodos de carga de datos

        private async Task CargarReservas()
        {
            try
            {
                var reservas = await _httpClient
                    .GetFromJsonAsync<List<Reserva>>(
                        "api/reserva",                               // <-- singular
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


                dataGridViewReservas.DataSource = reservas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar reservas:\n{ex}\n\nInnerException:\n{ex.InnerException}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private async Task CargarCanchas()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/cancha");
                response.EnsureSuccessStatusCode();

                var canchas = await response.Content
                    .ReadFromJsonAsync<List<Cancha>>();

                cmbCanchas.DataSource = canchas;
                cmbCanchas.DisplayMember = "Nombre";
                cmbCanchas.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar canchas:\n{ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }




        private async void btnCrear_Click(object sender, EventArgs e)
        {
            // 1) Validaciones de entrada

            // Validar selección de cancha
            if (cmbCanchas.SelectedItem == null || !(cmbCanchas.SelectedItem is Cancha))
            {
                MessageBox.Show("Por favor seleccioná una cancha.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var canchaSeleccionada = (Cancha)cmbCanchas.SelectedItem;

            // Validar nombre de cliente
            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MessageBox.Show("El nombre del cliente no puede estar vacío.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar fecha
            if (dtpFecha.Value < DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser anterior a hoy.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar duración
            if (nudHoras.Value < 1 || nudHoras.Value > 8)
            {
                MessageBox.Show("La duración debe ser entre 1 y 8 horas.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Construcción de la reserva
            var reserva = new CrearReservaRequest
            {
                CanchaId = canchaSeleccionada.Id,
                ClienteNombre = txtCliente.Text.Trim(),
                FechaHora = dtpFecha.Value,
                DuracionHoras = (int)nudHoras.Value
            };

            // 3) Llamada al API
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/api/reserva", reserva);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Reserva creada correctamente.", "Ok",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la reserva:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(dataGridViewReservas.CurrentRow?.DataBoundItem is Reserva seleccionada))
            {
                MessageBox.Show("Seleccioná primero una reserva para editar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // aquí, 'seleccionada' ya está definida


            // Actualizamos el objeto con los valores nuevos
            seleccionada.FechaHora = dtpFecha.Value;
            seleccionada.DuracionHoras = (int)nudHoras.Value;
            seleccionada.CanchaId = (int)cmbCanchas.SelectedValue;

            try
            {
                // Serializamos
                var content = JsonSerializer.Serialize(seleccionada);

                // --- Bloque using clásico en lugar de 'using var' ---
                using (var body = new StringContent(
                    content, Encoding.UTF8, "application/json"))
                {
                    var resp = await _httpClient.PutAsync(
                        $"/api/reserva/{seleccionada.Id}", body);
                    resp.EnsureSuccessStatusCode();
                }

                // Refrescamos la grilla
                await CargarReservas();
                MessageBox.Show("Reserva actualizada.",
                                "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la reserva:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            // 1) Obtener la fila actual
            var row = dataGridViewReservas.CurrentRow;

            // 2) Verificar que exista y que su DataBoundItem sea una Reserva
            if (row == null || !(row.DataBoundItem is Reserva seleccionada))
            {
                MessageBox.Show("Seleccioná primero una reserva para eliminar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3) Confirmar
            var respuesta = MessageBox.Show(
                $"¿Eliminar la reserva #{seleccionada.Id}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                // 4) Llamada DELETE
                var resp = await _httpClient.DeleteAsync($"/api/reserva/{seleccionada.Id}");
                resp.EnsureSuccessStatusCode();

                // 5) Refrescar
                await CargarReservas();
                MessageBox.Show("Reserva eliminada.",
                                "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la reserva:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewReservas.CurrentRow?.DataBoundItem is Reserva seleccionada)
            {
                dtpFecha.Value = seleccionada.FechaHora;
                nudHoras.Value = seleccionada.DuracionHoras;
                cmbCanchas.SelectedValue = seleccionada.CanchaId;
            }
        }

        public class Reserva
        {
            public int Id { get; set; }
            public int ClienteId { get; set; }
            public int CanchaId { get; set; }
            public DateTime FechaHora { get; set; }
            public int DuracionHoras { get; set; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbCanchas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            var url = "https://localhost:5001/api/reserva";

            // Usando la sintaxis clásica:
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                try
                {
                    var response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var reservas = JsonSerializer.Deserialize<List<Reserva>>(json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dataGridViewReservas.DataSource = reservas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar reservas:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
