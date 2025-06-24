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
using ReservasCanchaFutbol2.Desktop.Models;



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
                httpClient.BaseAddress = new Uri("https://localhost:7259");

                var response = await httpClient.PostAsJsonAsync("/api/usuario/login", usuario);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<Usuario>();
                    UsuarioActual.Id = data.Id;
                    UsuarioActual.NombreUsuario = data.NombreUsuario;

                    var mainForm = new Form1();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            var registroForm = new RegistroForm();
            registroForm.ShowDialog(); // Se abre como ventana modal, el usuario debe cerrarla para volver al login
        }
        public static class UsuarioActual
        {
            public static int Id;
            public static string NombreUsuario;
        }


    }

}
