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

            this.BackColor = Color.FromArgb(245, 245, 250);
            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Crear Nuevo Usuario";
            lblTitulo.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(52, 73, 94);
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Width = 350;
            lblTitulo.Height = 40;
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, 10);
            this.Controls.Add(lblTitulo);

            // Botón Registrarse
            btnRegistrar.BackColor = Color.FromArgb(40, 167, 69);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnRegistrar.Height = 30;
            btnRegistrar.Width = 100;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.UseVisualStyleBackColor = false;

            // Botón Cancelar
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.FromArgb(40, 167, 69);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnCancelar.Height = 30;
            btnCancelar.Width = 100;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(40, 167, 69);
            btnCancelar.FlatAppearance.BorderSize = 2;
            btnCancelar.Text = "Cancelar";
            // TextBox Usuario
            txtNuevoUsuario.Font = new Font("Segoe UI", 12);
            txtNuevoUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNuevoUsuario.Width = 220;

            // TextBox Contraseña
            txtNuevaContraseña.Font = new Font("Segoe UI", 12);
            txtNuevaContraseña.BorderStyle = BorderStyle.FixedSingle;
            txtNuevaContraseña.Width = 220;

            //label
            lblNombre.BackColor = Color.Transparent;
            lblNombre.ForeColor = Color.FromArgb(39, 174, 96);
            lblNombre.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblNombre.AutoSize = true;

            lblContraseña.BackColor = Color.Transparent;
            lblContraseña.ForeColor = Color.FromArgb(39, 174, 96);
            lblContraseña.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblContraseña.AutoSize = true;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
