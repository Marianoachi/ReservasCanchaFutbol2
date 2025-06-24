using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;


namespace ReservasCanchaFutbol2.Desktop
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            var usuario = new
            {
                NombreUsuario = txtNuevoUsuario.Text,
                Contraseña = txtNuevaContraseña.Text
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7259"); // Ajustá el puerto

                var response = await httpClient.PostAsJsonAsync("/api/usuario", usuario);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Usuario registrado correctamente!");
                    this.Close(); // Cierra el form de registro y vuelve al login
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al registrar usuario:\n" + error);
                }
            }
        }

    }
}
