namespace ReservasCanchaFutbol.UI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cmbCanchas = new System.Windows.Forms.ComboBox();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblUsuarioActual = new System.Windows.Forms.Label();
            this.nudHoras = new System.Windows.Forms.NumericUpDown();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblCancha = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFechaHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoras)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.SystemColors.Window;
            this.btnCrear.Location = new System.Drawing.Point(299, 197);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(135, 35);
            this.btnCrear.TabIndex = 15;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(639, 197);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(151, 35);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(456, 197);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(167, 35);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cmbCanchas
            // 
            this.cmbCanchas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCanchas.FormattingEnabled = true;
            this.cmbCanchas.Location = new System.Drawing.Point(589, 135);
            this.cmbCanchas.Name = "cmbCanchas";
            this.cmbCanchas.Size = new System.Drawing.Size(201, 24);
            this.cmbCanchas.TabIndex = 19;
            this.cmbCanchas.SelectedIndexChanged += new System.EventHandler(this.cmbCanchas_SelectedIndexChanged);
            // 
            // dgvReservas
            // 
            this.dgvReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservas.Location = new System.Drawing.Point(20, 256);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.ReadOnly = true;
            this.dgvReservas.RowHeadersWidth = 51;
            this.dgvReservas.RowTemplate.Height = 24;
            this.dgvReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservas.Size = new System.Drawing.Size(816, 138);
            this.dgvReservas.TabIndex = 6;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(614, 400);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(176, 35);
            this.btnCerrarSesion.TabIndex = 22;
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblUsuarioActual
            // 
            this.lblUsuarioActual.AutoSize = true;
            this.lblUsuarioActual.Location = new System.Drawing.Point(746, 9);
            this.lblUsuarioActual.Name = "lblUsuarioActual";
            this.lblUsuarioActual.Size = new System.Drawing.Size(44, 16);
            this.lblUsuarioActual.TabIndex = 23;
            this.lblUsuarioActual.Text = "label3";
            this.lblUsuarioActual.Click += new System.EventHandler(this.lblUsuarioActual_Click);
            // 
            // nudHoras
            // 
            this.nudHoras.Location = new System.Drawing.Point(384, 135);
            this.nudHoras.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHoras.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHoras.Name = "nudHoras";
            this.nudHoras.Size = new System.Drawing.Size(120, 22);
            this.nudHoras.TabIndex = 13;
            this.nudHoras.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(381, 94);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(106, 16);
            this.lblDuracion.TabIndex = 14;
            this.lblDuracion.Text = "Duracion(horas):";
            // 
            // lblCancha
            // 
            this.lblCancha.AutoSize = true;
            this.lblCancha.Location = new System.Drawing.Point(586, 94);
            this.lblCancha.Name = "lblCancha";
            this.lblCancha.Size = new System.Drawing.Size(91, 16);
            this.lblCancha.TabIndex = 24;
            this.lblCancha.Text = "Elegir Cancha";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(62, 36);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(0, 16);
            this.lblTitulo.TabIndex = 25;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "\"dd/MM/yyyy HH:mm\"";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(81, 135);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShowUpDown = true;
            this.dtpFecha.Size = new System.Drawing.Size(249, 22);
            this.dtpFecha.TabIndex = 9;
            this.dtpFecha.Tag = "";
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.Location = new System.Drawing.Point(78, 94);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(85, 16);
            this.lblFechaHora.TabIndex = 10;
            this.lblFechaHora.Text = "Fecha y hora";
            this.lblFechaHora.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(848, 447);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblCancha);
            this.Controls.Add(this.lblUsuarioActual);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.cmbCanchas);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.nudHoras);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.dgvReservas);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cmbCanchas;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblUsuarioActual;
        private System.Windows.Forms.NumericUpDown nudHoras;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblCancha;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblFechaHora;
    }
}

