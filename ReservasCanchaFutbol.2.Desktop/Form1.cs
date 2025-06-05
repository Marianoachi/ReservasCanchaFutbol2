using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservasCanchaFutbol2.WinForms
{
    public partial class MainForm : Form
    {
        private readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5001/") // Cambiar según puerto real de la API
        };

        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await CargarCanchas();
        }

        private async Task CargarCanchas()
        {
            try
            {
                var canchas = await _httpClient.GetFromJsonAsync<List<Cancha>>("api/canchas");
                dgvCanchas.DataSource = canchas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar canchas: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {

        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var cancha = new Cancha
            {
                Nombre = txtNombre.Text,
                Tipo = txtTipo.Text,
                PrecioPorHora = decimal.Parse(txtPrecio.Text)
            };

            var response = await _httpClient.PostAsJsonAsync("api/canchas", cancha);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Cancha agregada con éxito");
                await CargarCanchas();
            }
            else
            {
                MessageBox.Show("Error al agregar cancha");
            }
        }
    }

    public class Cancha
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorHora { get; set; }
    }
}