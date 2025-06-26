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
            this.BackColor = Color.FromArgb(245, 245, 250);

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "⚽ Boulevard Canchas";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Width = 350;
            lblTitulo.Height = 40;
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 10);
            this.Controls.Add(lblTitulo);


            // TextBox Usuario
            txtUsuario.Font = new Font("Segoe UI", 12);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Width = 220;

            // TextBox Contraseña
            txtContraseña.Font = new Font("Segoe UI", 12);
            txtContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtContraseña.Width = 220;

            // Botón Login
            btnLogin.BackColor = Color.FromArgb(40, 167, 69);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.UseVisualStyleBackColor = false;

            // Botón Registrarse
            btnRegistrarse.BackColor = Color.White;
            btnRegistrarse.ForeColor = Color.FromArgb(40, 167, 69);
            btnRegistrarse.FlatStyle = FlatStyle.Flat;
            btnRegistrarse.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegistrarse.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnRegistrarse.FlatAppearance.BorderSize = 2;
            btnRegistrarse.Text = "Registrarse";


            lblNombre.BackColor = Color.Transparent;
            lblNombre.ForeColor = Color.FromArgb(39, 174, 96);
            lblNombre.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblNombre.AutoSize = true;

            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.ForeColor = Color.FromArgb(39, 174, 96);
            lblContraseña.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblContraseña.AutoSize = true;



        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Centra los controles respecto al formulario
            int formWidth = this.ClientSize.Width;

            int totalAnchoControles = txtUsuario.Width; // Suponiendo que txtUsuario y txtContraseña tienen el mismo ancho

            int centerX = (formWidth - totalAnchoControles) / 2;

            txtUsuario.Location = new Point(centerX, 100);
            txtContraseña.Location = new Point(centerX, txtUsuario.Bottom + 20);

            btnLogin.Location = new Point(centerX, txtContraseña.Bottom + 30);
            btnRegistrarse.Location = new Point(btnLogin.Right + 20, btnLogin.Top);

            // Si tenés un label de título, centralo también
            lblTitulo.Location = new Point((formWidth - lblTitulo.Width) / 2, 30);
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
