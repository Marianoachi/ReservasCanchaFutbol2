using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservasCanchaFutbol2.Desktop;
using ReservasCanchaFutbol2.Desktop.Models;


namespace ReservasCanchaFutbol.UI
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "http://localhost:7259/api/reserva";

        public Form1()
        {
            InitializeComponent();

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7259/")
            };

            this.Load += Form1_Load;




        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarReservas();
            await CargarCanchas();
            lblUsuarioActual.Text = $"Usuario: {UsuarioActual.NombreUsuario}";
        }


        // 1) Métodos de carga de datos

        private async Task CargarReservas()
        {
            try
            {
                List<Reserva> reservas;

                if (UsuarioActual.NombreUsuario == "admin")
                {
                    reservas = await _httpClient.GetFromJsonAsync<List<Reserva>>(
                        "api/reserva",
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    var usuarioId = UsuarioActual.Id;
                    reservas = await _httpClient.GetFromJsonAsync<List<Reserva>>(
                        $"api/reserva?usuarioId={usuarioId}",
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                dgvReservas.DataSource = reservas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar reservas:\n{ex}\n\nInnerException:\n{ex.InnerException}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static class UsuarioActual
        {
            public static int Id;
            public static string NombreUsuario;
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
            if (cmbCanchas.SelectedItem == null || !(cmbCanchas.SelectedItem is Cancha))
            {
                MessageBox.Show("Por favor seleccioná una cancha.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var canchaSeleccionada = (Cancha)cmbCanchas.SelectedItem;

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

            // construccion de la reserva
            var reserva = new CrearReservaRequest
            {
                CanchaId = canchaSeleccionada.Id,
                FechaHora = dtpFecha.Value,
                DuracionHoras = (int)nudHoras.Value,
                UsuarioId = UsuarioActual.Id
            };

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
            if (!(dgvReservas.CurrentRow?.DataBoundItem is Reserva seleccionada))
            {
                MessageBox.Show("Seleccioná primero una reserva para editar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            seleccionada.FechaHora = dtpFecha.Value;
            seleccionada.DuracionHoras = (int)nudHoras.Value;
            seleccionada.CanchaId = (int)cmbCanchas.SelectedValue;

            try
            {
                var content = JsonSerializer.Serialize(seleccionada);

                using (var body = new StringContent(
                    content, Encoding.UTF8, "application/json"))
                {
                    var resp = await _httpClient.PutAsync(
                        $"/api/reserva/{seleccionada.Id}", body);
                    resp.EnsureSuccessStatusCode();
                }

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
            var row = dgvReservas.CurrentRow;

            if (row == null || !(row.DataBoundItem is Reserva seleccionada))
            {
                MessageBox.Show("Seleccioná primero una reserva para eliminar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Eliminar la reserva #{seleccionada.Id}?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                var resp = await _httpClient.DeleteAsync($"/api/reserva/{seleccionada.Id}");
                resp.EnsureSuccessStatusCode();

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
            if (dgvReservas.CurrentRow?.DataBoundItem is Reserva seleccionada)
            {
                dtpFecha.Value = seleccionada.FechaHora;
                nudHoras.Value = seleccionada.DuracionHoras;
                cmbCanchas.SelectedValue = seleccionada.CanchaId;
            }
        }

        public class Reserva
        {
            public int Id { get; set; }
            public int CanchaId { get; set; }
            public string Cancha { get; set; }
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

                    dgvReservas.DataSource = reservas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar reservas:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            UsuarioActual.Id = 0;
            UsuarioActual.NombreUsuario = "";

            var loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void lblUsuarioActual_Click(object sender, EventArgs e)
        {
            // No hace nada, solo está para evitar el error
        }

    }
}
