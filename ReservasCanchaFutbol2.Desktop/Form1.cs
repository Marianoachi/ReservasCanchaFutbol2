using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservasCanchaFutbol2.Desktop.Models;


namespace ReservasCanchaFutbol.UI
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "http://localhost:5193/api/reserva"; // Cambiar puerto si es necesario

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5193");

            Load += async (s, e) =>
            {
                await CargarCanchas();
                await CargarReservas();
            };
        }


        private async Task CargarReservas()
        {
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (cmbCanchas.SelectedItem is Cancha canchaSeleccionada)
            {
                var reserva = new CrearReservaRequest
                {
                    CanchaId = canchaSeleccionada.Id,
                    FechaHora = dtpFecha.Value,
                    DuracionHoras = (int)nudHoras.Value
                };

                var response = await _httpClient.PostAsJsonAsync("/api/reserva", reserva);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Reserva creada correctamente.");
                    // Podés refrescar la grilla de reservas si querés acá
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al crear la reserva:\n{error}");
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccioná una cancha.");
            }
        }


        private async Task CargarCanchas()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/cancha");
                response.EnsureSuccessStatusCode();

                var canchas = await response.Content.ReadFromJsonAsync<List<Cancha>>();

                cmbCanchas.DataSource = canchas;
                cmbCanchas.DisplayMember = "Nombre";
                cmbCanchas.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar canchas: {ex.Message}");
            }
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            label2.Text = dtpFecha.Text;
        }

        private void dgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow?.DataBoundItem is Reserva seleccionada)
            {
                txtClienteId.Text = seleccionada.ClienteId.ToString();
                txtCanchaId.Text = seleccionada.CanchaId.ToString();
                dtpFecha.Value = seleccionada.FechaHora;
                nudHoras.Value = seleccionada.DuracionHoras;
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
    }
}
