namespace CapaPresentacion.Formularios
{
    partial class frmCodPostales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCodPostales));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.txtFkLocal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.cboDepartamento = new System.Windows.Forms.ComboBox();
            this.cboProvincia = new System.Windows.Forms.ComboBox();
            this.txtFkProv = new System.Windows.Forms.TextBox();
            this.txtFkDepto = new System.Windows.Forms.TextBox();
            this.txtIdCodPos = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.dgvCodPostales = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fk_Local = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fk_Deptos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fk_Prov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodPostales)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1172, 40);
            this.pnlTitulo.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Actualización de Código Postales";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.txtFkLocal);
            this.pnlDeck.Controls.Add(this.label6);
            this.pnlDeck.Controls.Add(this.cboLocalidad);
            this.pnlDeck.Controls.Add(this.cboDepartamento);
            this.pnlDeck.Controls.Add(this.cboProvincia);
            this.pnlDeck.Controls.Add(this.txtFkProv);
            this.pnlDeck.Controls.Add(this.txtFkDepto);
            this.pnlDeck.Controls.Add(this.txtIdCodPos);
            this.pnlDeck.Controls.Add(this.txtLocalidad);
            this.pnlDeck.Controls.Add(this.label5);
            this.pnlDeck.Controls.Add(this.label4);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.dgvCodPostales);
            this.pnlDeck.Controls.Add(this.txtIndice);
            this.pnlDeck.Controls.Add(this.txtUserRegistro);
            this.pnlDeck.Controls.Add(this.txtId);
            this.pnlDeck.Controls.Add(this.btnLimpiar);
            this.pnlDeck.Controls.Add(this.txtCodigo);
            this.pnlDeck.Controls.Add(this.btnBuscar);
            this.pnlDeck.Controls.Add(this.txtFiltro);
            this.pnlDeck.Controls.Add(this.cboBusqueda);
            this.pnlDeck.Controls.Add(this.label10);
            this.pnlDeck.Controls.Add(this.label9);
            this.pnlDeck.Controls.Add(this.label2);
            this.pnlDeck.Controls.Add(this.label8);
            this.pnlDeck.Controls.Add(this.label3);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(1172, 463);
            this.pnlDeck.TabIndex = 12;
            // 
            // txtFkLocal
            // 
            this.txtFkLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFkLocal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFkLocal.Enabled = false;
            this.txtFkLocal.ForeColor = System.Drawing.Color.White;
            this.txtFkLocal.Location = new System.Drawing.Point(203, 220);
            this.txtFkLocal.Name = "txtFkLocal";
            this.txtFkLocal.Size = new System.Drawing.Size(35, 16);
            this.txtFkLocal.TabIndex = 86;
            this.txtFkLocal.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 85;
            this.label6.Text = "Localidad:";
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboLocalidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocalidad.ForeColor = System.Drawing.Color.White;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(146, 109);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(264, 25);
            this.cboLocalidad.TabIndex = 2;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboDepartamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDepartamento.ForeColor = System.Drawing.Color.White;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(146, 138);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(264, 25);
            this.cboDepartamento.TabIndex = 3;
            // 
            // cboProvincia
            // 
            this.cboProvincia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboProvincia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProvincia.ForeColor = System.Drawing.Color.White;
            this.cboProvincia.FormattingEnabled = true;
            this.cboProvincia.Location = new System.Drawing.Point(146, 167);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Size = new System.Drawing.Size(264, 25);
            this.cboProvincia.TabIndex = 4;
            // 
            // txtFkProv
            // 
            this.txtFkProv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFkProv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFkProv.Enabled = false;
            this.txtFkProv.ForeColor = System.Drawing.Color.White;
            this.txtFkProv.Location = new System.Drawing.Point(286, 220);
            this.txtFkProv.Name = "txtFkProv";
            this.txtFkProv.Size = new System.Drawing.Size(35, 16);
            this.txtFkProv.TabIndex = 83;
            this.txtFkProv.Visible = false;
            // 
            // txtFkDepto
            // 
            this.txtFkDepto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFkDepto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFkDepto.Enabled = false;
            this.txtFkDepto.ForeColor = System.Drawing.Color.White;
            this.txtFkDepto.Location = new System.Drawing.Point(245, 220);
            this.txtFkDepto.Name = "txtFkDepto";
            this.txtFkDepto.Size = new System.Drawing.Size(35, 16);
            this.txtFkDepto.TabIndex = 82;
            this.txtFkDepto.Visible = false;
            // 
            // txtIdCodPos
            // 
            this.txtIdCodPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIdCodPos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdCodPos.Enabled = false;
            this.txtIdCodPos.ForeColor = System.Drawing.Color.White;
            this.txtIdCodPos.Location = new System.Drawing.Point(162, 220);
            this.txtIdCodPos.Name = "txtIdCodPos";
            this.txtIdCodPos.Size = new System.Drawing.Size(35, 16);
            this.txtIdCodPos.TabIndex = 81;
            this.txtIdCodPos.Visible = false;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLocalidad.ForeColor = System.Drawing.Color.White;
            this.txtLocalidad.Location = new System.Drawing.Point(146, 82);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(264, 23);
            this.txtLocalidad.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 17);
            this.label5.TabIndex = 80;
            this.label5.Text = "Nueva Localidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 78;
            this.label4.Text = "Provincia:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(28, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 86);
            this.groupBox1.TabIndex = 76;
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
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.BroomBall;
            this.btnClear.IconColor = System.Drawing.Color.Aqua;
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.IconSize = 30;
            this.btnClear.Location = new System.Drawing.Point(149, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 53);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Limpiar";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.Share;
            this.btnSalir.IconColor = System.Drawing.Color.Aqua;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 30;
            this.btnSalir.Location = new System.Drawing.Point(285, 22);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvCodPostales
            // 
            this.dgvCodPostales.AllowUserToAddRows = false;
            this.dgvCodPostales.AllowUserToDeleteRows = false;
            this.dgvCodPostales.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCodPostales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCodPostales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvCodPostales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodPostales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCodPostales.ColumnHeadersHeight = 30;
            this.dgvCodPostales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodPostales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.id_Local,
            this.fk_Local,
            this.fk_Deptos,
            this.fk_Prov,
            this.Codigo,
            this.Localidad,
            this.Departamento,
            this.Provincia});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCodPostales.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCodPostales.EnableHeadersVisualStyles = false;
            this.dgvCodPostales.GridColor = System.Drawing.Color.White;
            this.dgvCodPostales.Location = new System.Drawing.Point(437, 53);
            this.dgvCodPostales.MultiSelect = false;
            this.dgvCodPostales.Name = "dgvCodPostales";
            this.dgvCodPostales.ReadOnly = true;
            this.dgvCodPostales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodPostales.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvCodPostales.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCodPostales.Size = new System.Drawing.Size(678, 385);
            this.dgvCodPostales.TabIndex = 71;
            this.dgvCodPostales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCodPostales_CellContentClick);
            this.dgvCodPostales.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCodPostales_CellPainting);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 25;
            // 
            // id_Local
            // 
            this.id_Local.HeaderText = "id";
            this.id_Local.Name = "id_Local";
            this.id_Local.ReadOnly = true;
            this.id_Local.Visible = false;
            // 
            // fk_Local
            // 
            this.fk_Local.HeaderText = "fk_Local";
            this.fk_Local.Name = "fk_Local";
            this.fk_Local.ReadOnly = true;
            this.fk_Local.Visible = false;
            // 
            // fk_Deptos
            // 
            this.fk_Deptos.HeaderText = "fk_Deptos";
            this.fk_Deptos.Name = "fk_Deptos";
            this.fk_Deptos.ReadOnly = true;
            this.fk_Deptos.Visible = false;
            // 
            // fk_Prov
            // 
            this.fk_Prov.HeaderText = "fk_Prov";
            this.fk_Prov.Name = "fk_Prov";
            this.fk_Prov.ReadOnly = true;
            this.fk_Prov.Visible = false;
            // 
            // Codigo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.HeaderText = "CODIGO";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // Localidad
            // 
            this.Localidad.HeaderText = "LOCALIDAD";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.Width = 180;
            // 
            // Departamento
            // 
            this.Departamento.HeaderText = "DEPARTAMENTO";
            this.Departamento.Name = "Departamento";
            this.Departamento.ReadOnly = true;
            this.Departamento.Width = 180;
            // 
            // Provincia
            // 
            this.Provincia.HeaderText = "PROVINCIA";
            this.Provincia.Name = "Provincia";
            this.Provincia.ReadOnly = true;
            this.Provincia.Width = 150;
            // 
            // txtIndice
            // 
            this.txtIndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtIndice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndice.Enabled = false;
            this.txtIndice.ForeColor = System.Drawing.Color.White;
            this.txtIndice.Location = new System.Drawing.Point(274, 198);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(65, 16);
            this.txtIndice.TabIndex = 75;
            this.txtIndice.Visible = false;
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(203, 198);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(65, 16);
            this.txtUserRegistro.TabIndex = 74;
            this.txtUserRegistro.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(148, 198);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 16);
            this.txtId.TabIndex = 60;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Aqua;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 25;
            this.btnLimpiar.Location = new System.Drawing.Point(1087, 16);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(28, 28);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.ForeColor = System.Drawing.Color.White;
            this.txtCodigo.Location = new System.Drawing.Point(146, 53);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(60, 23);
            this.txtCodigo.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Aqua;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 25;
            this.btnBuscar.Location = new System.Drawing.Point(1040, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(28, 28);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltro.ForeColor = System.Drawing.Color.White;
            this.txtFiltro.Location = new System.Drawing.Point(831, 19);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(199, 23);
            this.txtFiltro.TabIndex = 6;
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBusqueda.ForeColor = System.Drawing.Color.White;
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(685, 18);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(140, 25);
            this.cboBusqueda.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(600, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 17);
            this.label10.TabIndex = 73;
            this.label10.Text = "Buscar por:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(13, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(238, 22);
            this.label9.TabIndex = 72;
            this.label9.Text = "Detalle del Código Postal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "Código:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(433, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 22);
            this.label8.TabIndex = 54;
            this.label8.Text = "Lista de Códigos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "Departamento:";
            // 
            // frmCodPostales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1172, 503);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCodPostales";
            this.Text = "ACTUALIZACIÓN DE CÓDIGOS POSTALES";
            this.Load += new System.EventHandler(this.frmCodPostales_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodPostales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.DataGridView dgvCodPostales;
        private System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.TextBox txtId;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.TextBox txtCodigo;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFkProv;
        private System.Windows.Forms.TextBox txtFkDepto;
        private System.Windows.Forms.TextBox txtIdCodPos;
        private System.Windows.Forms.ComboBox cboProvincia;
        private System.Windows.Forms.ComboBox cboDepartamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.TextBox txtFkLocal;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn fk_Local;
        private System.Windows.Forms.DataGridViewTextBoxColumn fk_Deptos;
        private System.Windows.Forms.DataGridViewTextBoxColumn fk_Prov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Provincia;
    }
}