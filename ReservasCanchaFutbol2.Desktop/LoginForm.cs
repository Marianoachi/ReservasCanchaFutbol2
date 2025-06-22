using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Json;
using ReservasCanchaFutbol.UI;


namespace ReservasCanchaFutbol2.Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var usuario = new
            {
                nombreUsuario = txtUsuario.Text,
                contraseña = txtContraseña.Text
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7259"); // o tu puerto real

                var response = await httpClient.PostAsJsonAsync("/api/usuario/login", usuario);

                if (response.IsSuccessStatusCode)
                {
                    // Login correcto: abrir el formulario principal
                    var mainForm = new Form1(); // o Form1, según tu proyecto
                    mainForm.Show();
                    this.Hide(); // Oculta el LoginForm
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }

}
