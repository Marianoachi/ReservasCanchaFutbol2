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
            this.BackColor = Color.FromArgb(245, 245, 250);
            InitializeComponent();
            dgvReservas.EnableHeadersVisualStyles = false;
            dgvReservas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(40, 167, 69);
            dgvReservas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReservas.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReservas.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            dgvReservas.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.BorderStyle = BorderStyle.None;
            lblFechaHora.BackColor = Color.FromArgb(220, 255, 255, 255);
            lblDuracion.BackColor = Color.FromArgb(220, 255, 255, 255);
            lblCancha.BackColor = Color.FromArgb(220, 255, 255, 255);

            Label lblTitulo = new Label();
            lblTitulo.Text = "Reserva tu cancha";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Width = 350;
            lblTitulo.Height = 40;
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 10);
            this.Controls.Add(lblTitulo);
            // Labels
            lblFechaHora.BackColor = Color.Transparent;
            lblFechaHora.ForeColor = Color.FromArgb(39, 174, 96);
            lblFechaHora.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblFechaHora.AutoSize = true;

            lblDuracion.BackColor = Color.Transparent;
            lblDuracion.ForeColor = Color.FromArgb(39, 174, 96);
            lblDuracion.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblDuracion.AutoSize = true;

            lblCancha.BackColor = Color.Transparent;

            nudHoras.ForeColor = Color.Black; // Negro
            lblCancha.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblCancha.AutoSize = true;

            cmbCanchas.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dtpFecha.Font = new Font("Segoe UI", 11, FontStyle.Regular);

            cmbCanchas.BackColor = Color.White;

            nudHoras.ForeColor = Color.Black;
            dtpFecha.CalendarForeColor = Color.FromArgb(39, 174, 96);
            dtpFecha.CalendarMonthBackground = Color.White;

            //horas
            nudHoras.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            nudHoras.BackColor = Color.White;
            nudHoras.ForeColor = Color.Black;
            nudHoras.Minimum = 1;
            nudHoras.Maximum = 6;
            nudHoras.TextAlign = HorizontalAlignment.Center;



            // Botones estilo flat y mismos tamaños
            Button[] botones = { btnCrear, btnEditar, btnEliminar, btnCerrarSesion };
            foreach (var btn in botones)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.White;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            }

            btnCrear.Text = "Crear Reserva";
            btnEditar.Text = "Editar Reserva";
            btnEliminar.Text = "Eliminar Reserva";
            btnCerrarSesion.Text ="Cerrar Sesion";

            // DataGridView estilizado
            dgvReservas.BackgroundColor = Color.White;
            dgvReservas.BorderStyle = BorderStyle.None;
            dgvReservas.RowHeadersVisible = false;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



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


        public static class UsuarioActual
        {
            public static int Id;
            public static string NombreUsuario;
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
                dgvReservas.Columns["Id"].Visible = false;
                dgvReservas.Columns["CanchaId"].Visible = false;
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

            // Validar duracion
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
                MessageBox.Show($"Error al crear la reserva: Ya existe una reserva en este horario",
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

        public class CrearReservaRequest
        {
            public int Id { get; set; }
            public int CanchaId { get; set; }
            public string Cancha { get; set; }
            public DateTime FechaHora { get; set; }
            public int DuracionHoras { get; set; }
            public int UsuarioId   { get; set; }
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
