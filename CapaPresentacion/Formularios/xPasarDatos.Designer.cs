namespace CapaPresentacion.Formularios
{
    partial class xPasarDatos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProcesar = new System.Windows.Forms.Button();
            this.dgvCodigosPostales = new System.Windows.Forms.DataGridView();
            this.id_Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departamento1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provincia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigosPostales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(357, 12);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(75, 23);
            this.btnProcesar.TabIndex = 0;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // dgvCodigosPostales
            // 
            this.dgvCodigosPostales.AllowUserToAddRows = false;
            this.dgvCodigosPostales.AllowUserToDeleteRows = false;
            this.dgvCodigosPostales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodigosPostales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Cod,
            this.Codigo1,
            this.Localidad1,
            this.Departamento1,
            this.Provincia1});
            this.dgvCodigosPostales.Location = new System.Drawing.Point(12, 41);
            this.dgvCodigosPostales.Name = "dgvCodigosPostales";
            this.dgvCodigosPostales.ReadOnly = true;
            this.dgvCodigosPostales.Size = new System.Drawing.Size(864, 443);
            this.dgvCodigosPostales.TabIndex = 1;
            // 
            // id_Cod
            // 
            this.id_Cod.HeaderText = "id_Cod";
            this.id_Cod.Name = "id_Cod";
            this.id_Cod.ReadOnly = true;
            // 
            // Codigo1
            // 
            this.Codigo1.HeaderText = "Codigo";
            this.Codigo1.Name = "Codigo1";
            this.Codigo1.ReadOnly = true;
            // 
            // Localidad1
            // 
            this.Localidad1.HeaderText = "Localidad";
            this.Localidad1.Name = "Localidad1";
            this.Localidad1.ReadOnly = true;
            this.Localidad1.Width = 200;
            // 
            // Departamento1
            // 
            this.Departamento1.HeaderText = "Departamento";
            this.Departamento1.Name = "Departamento1";
            this.Departamento1.ReadOnly = true;
            this.Departamento1.Width = 200;
            // 
            // Provincia1
            // 
            this.Provincia1.HeaderText = "Provincia";
            this.Provincia1.Name = "Provincia1";
            this.Provincia1.ReadOnly = true;
            this.Provincia1.Width = 200;
            // 
            // xPasarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 508);
            this.Controls.Add(this.dgvCodigosPostales);
            this.Controls.Add(this.btnProcesar);
            this.Name = "xPasarDatos";
            this.Text = "xPasarDatos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodigosPostales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.DataGridView dgvCodigosPostales;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departamento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provincia1;
    }
}