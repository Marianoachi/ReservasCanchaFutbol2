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
            this.txtCanchaId = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cmbCanchas = new System.Windows.Forms.ComboBox();
            this.dataGridViewReservas = new System.Windows.Forms.DataGridView();
            this.nudHoras = new System.Windows.Forms.NumericUpDown();
            this.panelGrid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).BeginInit();
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
            // txtCanchaId
            // 
            this.txtCanchaId.Location = new System.Drawing.Point(12, 261);
            this.txtCanchaId.Name = "txtCanchaId";
            this.txtCanchaId.Size = new System.Drawing.Size(100, 22);
            this.txtCanchaId.TabIndex = 8;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(303, 91);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 9;
            this.dtpFecha.Tag = "";
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha y hora";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Cancha ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Duracion(horas):";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(70, 138);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 15;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(460, 138);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 16;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(303, 138);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(176, 138);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 23);
            this.btnCargar.TabIndex = 20;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(677, 350);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 22);
            this.txtCliente.TabIndex = 21;
            // 
            // cmbCanchas
            // 
            this.cmbCanchas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCanchas.FormattingEnabled = true;
            this.cmbCanchas.Location = new System.Drawing.Point(549, 59);
            this.cmbCanchas.Name = "cmbCanchas";
            this.cmbCanchas.Size = new System.Drawing.Size(121, 24);
            this.cmbCanchas.TabIndex = 19;
            this.cmbCanchas.SelectedIndexChanged += new System.EventHandler(this.cmbCanchas_SelectedIndexChanged);
            // 
            // dataGridViewReservas
            // 
            this.dataGridViewReservas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReservas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReservas.Location = new System.Drawing.Point(132, 197);
            this.dataGridViewReservas.Name = "dataGridViewReservas";
            this.dataGridViewReservas.ReadOnly = true;
            this.dataGridViewReservas.RowHeadersWidth = 51;
            this.dataGridViewReservas.RowTemplate.Height = 24;
            this.dataGridViewReservas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReservas.Size = new System.Drawing.Size(514, 150);
            this.dataGridViewReservas.TabIndex = 6;
            // 
            // nudHoras
            // 
            this.nudHoras.Location = new System.Drawing.Point(70, 91);
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
            // panelGrid
            // 
            this.panelGrid.Location = new System.Drawing.Point(686, 36);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(250, 125);
            this.panelGrid.TabIndex = 22;
            this.panelGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 388);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.cmbCanchas);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudHoras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewReservas);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtCanchaId);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCanchaId;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cmbCanchas;
        private System.Windows.Forms.DataGridView dataGridViewReservas;
        private System.Windows.Forms.NumericUpDown nudHoras;
        private System.Windows.Forms.Panel panelGrid;
    }
}

