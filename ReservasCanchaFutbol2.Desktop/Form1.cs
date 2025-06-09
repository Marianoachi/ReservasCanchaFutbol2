using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Windows.Forms;

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
            _httpClient.BaseAddress = new Uri("http://localhost:5193"); // Cambiar si es necesario
            CargarReservas();
        }

        private async void CargarReservas()
        {
            var reservas = await _httpClient.GetFromJsonAsync<List<Reserva>>("api/reserva");
            dgvReservas.DataSource = reservas;
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            var nueva = new Reserva
            {
                ClienteId = int.Parse(txtClienteId.Text),
                CanchaId = int.Parse(txtCanchaId.Text),
                FechaHora = dtpFecha.Value,
                DuracionHoras = (int)nudHoras.Value
            };

            var response = await _httpClient.PostAsJsonAsync("api/reserva", nueva);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Reserva creada");
                CargarReservas();
            }
            else
            {
                MessageBox.Show("Error al crear");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow?.DataBoundItem is Reserva seleccionada)
            {
                var response = await _httpClient.DeleteAsync($"api/reserva/{seleccionada.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Eliminada");
                    CargarReservas();
                }
                else
                {
                    MessageBox.Show("Error al eliminar");
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow?.DataBoundItem is Reserva seleccionada)
            {
                seleccionada.ClienteId = int.Parse(txtClienteId.Text);
                seleccionada.CanchaId = int.Parse(txtCanchaId.Text);
                seleccionada.FechaHora = dtpFecha.Value;
                seleccionada.DuracionHoras = (int)nudHoras.Value;

                var response = await _httpClient.PutAsJsonAsync($"api/reserva/{seleccionada.Id}", seleccionada);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Editada");
                    CargarReservas();
                }
                else
                {
                    MessageBox.Show("Error al editar");
                }
            }
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

        private void btnCrear_Click_1(object sender, EventArgs e)
        {

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
}
