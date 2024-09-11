
namespace CapaPresentacion.Formularios
{
    partial class mdlPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdlPlan));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboProfesionales = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboTipoConsulta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMinutosDes = new System.Windows.Forms.NumericUpDown();
            this.nudHoraDes = new System.Windows.Forms.NumericUpDown();
            this.nudMinutosHas = new System.Windows.Forms.NumericUpDown();
            this.nudHoraHas = new System.Windows.Forms.NumericUpDown();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.nudRango = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosDes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraDes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosHas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraHas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRango)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 41);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(131, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Planificación";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(15, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(245, 22);
            this.label9.TabIndex = 75;
            this.label9.Text = "Detalle de la Planificación";
            // 
            // cboProfesionales
            // 
            this.cboProfesionales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboProfesionales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProfesionales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProfesionales.ForeColor = System.Drawing.Color.White;
            this.cboProfesionales.FormattingEnabled = true;
            this.cboProfesionales.Location = new System.Drawing.Point(97, 83);
            this.cboProfesionales.Name = "cboProfesionales";
            this.cboProfesionales.Size = new System.Drawing.Size(190, 24);
            this.cboProfesionales.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 152;
            this.label8.Text = "Profesional:";
            // 
            // cboTipoConsulta
            // 
            this.cboTipoConsulta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboTipoConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTipoConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoConsulta.ForeColor = System.Drawing.Color.White;
            this.cboTipoConsulta.FormattingEnabled = true;
            this.cboTipoConsulta.Items.AddRange(new object[] {
            "Ecocardiograma Doppler Color Pediátrico",
            "Ecocardiograma Doppler Color Fetal",
            "Electrocardiograma + Consulta (Prequirúrgico)",
            "Consulta + Electrocardiograma",
            "Consulta",
            "Consulta + Espirometría",
            "Videofribrolaringoscopía",
            "Consulta S/R"});
            this.cboTipoConsulta.Location = new System.Drawing.Point(97, 110);
            this.cboTipoConsulta.Name = "cboTipoConsulta";
            this.cboTipoConsulta.Size = new System.Drawing.Size(354, 24);
            this.cboTipoConsulta.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(52, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 316;
            this.label3.Text = "Tipo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(21, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 86);
            this.groupBox1.TabIndex = 317;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.Aqua;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 30;
            this.btnGuardar.Location = new System.Drawing.Point(9, 22);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(70, 53);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminar.IconColor = System.Drawing.Color.Aqua;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 30;
            this.btnEliminar.Location = new System.Drawing.Point(184, 22);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(70, 53);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.MailForward;
            this.btnSalir.IconColor = System.Drawing.Color.Aqua;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 30;
            this.btnSalir.Location = new System.Drawing.Point(347, 22);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 319;
            this.label2.Text = "Desde:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(201, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 321;
            this.label4.Text = "Hasta:";
            // 
            // nudMinutosDes
            // 
            this.nudMinutosDes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudMinutosDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudMinutosDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinutosDes.ForeColor = System.Drawing.Color.White;
            this.nudMinutosDes.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinutosDes.Location = new System.Drawing.Point(147, 137);
            this.nudMinutosDes.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMinutosDes.Name = "nudMinutosDes";
            this.nudMinutosDes.Size = new System.Drawing.Size(44, 22);
            this.nudMinutosDes.TabIndex = 3;
            this.nudMinutosDes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudHoraDes
            // 
            this.nudHoraDes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudHoraDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudHoraDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHoraDes.ForeColor = System.Drawing.Color.White;
            this.nudHoraDes.Location = new System.Drawing.Point(97, 137);
            this.nudHoraDes.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHoraDes.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHoraDes.Name = "nudHoraDes";
            this.nudHoraDes.Size = new System.Drawing.Size(44, 22);
            this.nudHoraDes.TabIndex = 2;
            this.nudHoraDes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHoraDes.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // nudMinutosHas
            // 
            this.nudMinutosHas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudMinutosHas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudMinutosHas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinutosHas.ForeColor = System.Drawing.Color.White;
            this.nudMinutosHas.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinutosHas.Location = new System.Drawing.Point(304, 137);
            this.nudMinutosHas.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudMinutosHas.Name = "nudMinutosHas";
            this.nudMinutosHas.Size = new System.Drawing.Size(44, 22);
            this.nudMinutosHas.TabIndex = 5;
            this.nudMinutosHas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudHoraHas
            // 
            this.nudHoraHas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudHoraHas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudHoraHas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHoraHas.ForeColor = System.Drawing.Color.White;
            this.nudHoraHas.Location = new System.Drawing.Point(254, 137);
            this.nudHoraHas.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHoraHas.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHoraHas.Name = "nudHoraHas";
            this.nudHoraHas.Size = new System.Drawing.Size(44, 22);
            this.nudHoraHas.TabIndex = 4;
            this.nudHoraHas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudHoraHas.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // txtDia
            // 
            this.txtDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDia.ForeColor = System.Drawing.Color.Yellow;
            this.txtDia.Location = new System.Drawing.Point(266, 48);
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(95, 22);
            this.txtDia.TabIndex = 322;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(367, 53);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 13);
            this.txtId.TabIndex = 323;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(367, 72);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(68, 13);
            this.txtUserRegistro.TabIndex = 324;
            this.txtUserRegistro.Visible = false;
            // 
            // nudRango
            // 
            this.nudRango.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.nudRango.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRango.ForeColor = System.Drawing.Color.White;
            this.nudRango.Location = new System.Drawing.Point(407, 137);
            this.nudRango.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRango.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRango.Name = "nudRango";
            this.nudRango.Size = new System.Drawing.Size(44, 22);
            this.nudRango.TabIndex = 325;
            this.nudRango.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRango.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(354, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 326;
            this.label5.Text = "Rango:";
            // 
            // mdlPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(477, 271);
            this.Controls.Add(this.nudRango);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserRegistro);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtDia);
            this.Controls.Add(this.nudMinutosHas);
            this.Controls.Add(this.nudHoraHas);
            this.Controls.Add(this.nudMinutosDes);
            this.Controls.Add(this.nudHoraDes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cboTipoConsulta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboProfesionales);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mdlPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLANIFICAR";
            this.Load += new System.EventHandler(this.mdlPlan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosDes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraDes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutosHas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraHas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRango)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboProfesionales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoConsulta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMinutosDes;
        private System.Windows.Forms.NumericUpDown nudHoraDes;
        private System.Windows.Forms.NumericUpDown nudMinutosHas;
        private System.Windows.Forms.NumericUpDown nudHoraHas;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.NumericUpDown nudRango;
        private System.Windows.Forms.Label label5;
    }
}