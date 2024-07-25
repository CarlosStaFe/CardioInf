namespace CapaPresentacion.Formularios
{
    partial class frmVerAgenda
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerAgenda));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.txtFechaRegistro = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtUserRegistro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeck = new System.Windows.Forms.Panel();
            this.txtNumeroDoc = new System.Windows.Forms.TextBox();
            this.txtTipoDoc = new System.Windows.Forms.TextBox();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.txtFecNacim = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.dgvAgendas = new System.Windows.Forms.DataGridView();
            this.label34 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.lblHC = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnHC = new FontAwesome.Sharp.IconButton();
            this.dtpFecha = new CapaPresentacion.DatePicker();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.id_Plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Minutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoyNombres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoEst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pacte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FecEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTitulo.SuspendLayout();
            this.pnlDeck.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.Controls.Add(this.txtPaciente);
            this.pnlTitulo.Controls.Add(this.txtIndice);
            this.pnlTitulo.Controls.Add(this.txtFechaRegistro);
            this.pnlTitulo.Controls.Add(this.txtId);
            this.pnlTitulo.Controls.Add(this.txtUserRegistro);
            this.pnlTitulo.Controls.Add(this.label1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1168, 40);
            this.pnlTitulo.TabIndex = 16;
            // 
            // txtPaciente
            // 
            this.txtPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtPaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaciente.Enabled = false;
            this.txtPaciente.ForeColor = System.Drawing.Color.White;
            this.txtPaciente.Location = new System.Drawing.Point(747, 11);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(53, 16);
            this.txtPaciente.TabIndex = 135;
            this.txtPaciente.Visible = false;
            // 
            // txtIndice
            // 
            this.txtIndice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtIndice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIndice.Enabled = false;
            this.txtIndice.ForeColor = System.Drawing.Color.White;
            this.txtIndice.Location = new System.Drawing.Point(806, 11);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(53, 16);
            this.txtIndice.TabIndex = 134;
            this.txtIndice.Visible = false;
            // 
            // txtFechaRegistro
            // 
            this.txtFechaRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtFechaRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFechaRegistro.Enabled = false;
            this.txtFechaRegistro.ForeColor = System.Drawing.Color.White;
            this.txtFechaRegistro.Location = new System.Drawing.Point(964, 11);
            this.txtFechaRegistro.Name = "txtFechaRegistro";
            this.txtFechaRegistro.Size = new System.Drawing.Size(53, 16);
            this.txtFechaRegistro.TabIndex = 133;
            this.txtFechaRegistro.Visible = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtId.Enabled = false;
            this.txtId.ForeColor = System.Drawing.Color.White;
            this.txtId.Location = new System.Drawing.Point(865, 11);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(34, 16);
            this.txtId.TabIndex = 54;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // txtUserRegistro
            // 
            this.txtUserRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtUserRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserRegistro.Enabled = false;
            this.txtUserRegistro.ForeColor = System.Drawing.Color.White;
            this.txtUserRegistro.Location = new System.Drawing.Point(905, 11);
            this.txtUserRegistro.Name = "txtUserRegistro";
            this.txtUserRegistro.Size = new System.Drawing.Size(53, 16);
            this.txtUserRegistro.TabIndex = 53;
            this.txtUserRegistro.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Visualización de Agenda Médica";
            // 
            // pnlDeck
            // 
            this.pnlDeck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlDeck.Controls.Add(this.txtNumeroDoc);
            this.pnlDeck.Controls.Add(this.txtTipoDoc);
            this.pnlDeck.Controls.Add(this.txtSexo);
            this.pnlDeck.Controls.Add(this.txtFecNacim);
            this.pnlDeck.Controls.Add(this.groupBox1);
            this.pnlDeck.Controls.Add(this.dgvAgendas);
            this.pnlDeck.Controls.Add(this.label34);
            this.pnlDeck.Controls.Add(this.panel1);
            this.pnlDeck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDeck.Location = new System.Drawing.Point(0, 40);
            this.pnlDeck.Name = "pnlDeck";
            this.pnlDeck.Size = new System.Drawing.Size(1168, 540);
            this.pnlDeck.TabIndex = 17;
            // 
            // txtNumeroDoc
            // 
            this.txtNumeroDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtNumeroDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroDoc.Enabled = false;
            this.txtNumeroDoc.ForeColor = System.Drawing.Color.White;
            this.txtNumeroDoc.Location = new System.Drawing.Point(1060, 27);
            this.txtNumeroDoc.Name = "txtNumeroDoc";
            this.txtNumeroDoc.Size = new System.Drawing.Size(35, 16);
            this.txtNumeroDoc.TabIndex = 153;
            this.txtNumeroDoc.Visible = false;
            // 
            // txtTipoDoc
            // 
            this.txtTipoDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTipoDoc.Enabled = false;
            this.txtTipoDoc.ForeColor = System.Drawing.Color.White;
            this.txtTipoDoc.Location = new System.Drawing.Point(1019, 27);
            this.txtTipoDoc.Name = "txtTipoDoc";
            this.txtTipoDoc.Size = new System.Drawing.Size(35, 16);
            this.txtTipoDoc.TabIndex = 152;
            this.txtTipoDoc.Visible = false;
            // 
            // txtSexo
            // 
            this.txtSexo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtSexo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSexo.Enabled = false;
            this.txtSexo.ForeColor = System.Drawing.Color.White;
            this.txtSexo.Location = new System.Drawing.Point(1060, 5);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.Size = new System.Drawing.Size(35, 16);
            this.txtSexo.TabIndex = 151;
            this.txtSexo.Visible = false;
            // 
            // txtFecNacim
            // 
            this.txtFecNacim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtFecNacim.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFecNacim.Enabled = false;
            this.txtFecNacim.ForeColor = System.Drawing.Color.White;
            this.txtFecNacim.Location = new System.Drawing.Point(1019, 6);
            this.txtFecNacim.Name = "txtFecNacim";
            this.txtFecNacim.Size = new System.Drawing.Size(35, 16);
            this.txtFecNacim.TabIndex = 150;
            this.txtFecNacim.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(1011, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 471);
            this.groupBox1.TabIndex = 305;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.MailForward;
            this.btnSalir.IconColor = System.Drawing.Color.Aqua;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 30;
            this.btnSalir.Location = new System.Drawing.Point(14, 401);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(70, 53);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(14, 209);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(70, 53);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Visible = false;
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
            this.btnClear.Location = new System.Drawing.Point(14, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(70, 53);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Limpiar";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            // 
            // dgvAgendas
            // 
            this.dgvAgendas.AllowUserToAddRows = false;
            this.dgvAgendas.AllowUserToDeleteRows = false;
            this.dgvAgendas.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAgendas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAgendas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dgvAgendas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgendas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAgendas.ColumnHeadersHeight = 30;
            this.dgvAgendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAgendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar,
            this.id_Plan,
            this.FecTurno,
            this.Hora,
            this.Minutos,
            this.Turno,
            this.ApellidoyNombres,
            this.TipoEst,
            this.Pacte,
            this.Numero,
            this.Estado,
            this.FecEstado,
            this.Obs,
            this.Profesional,
            this.UserRegistro,
            this.FechaRegistro});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAgendas.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAgendas.EnableHeadersVisualStyles = false;
            this.dgvAgendas.GridColor = System.Drawing.Color.White;
            this.dgvAgendas.Location = new System.Drawing.Point(14, 57);
            this.dgvAgendas.MultiSelect = false;
            this.dgvAgendas.Name = "dgvAgendas";
            this.dgvAgendas.ReadOnly = true;
            this.dgvAgendas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAgendas.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Gray;
            this.dgvAgendas.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvAgendas.Size = new System.Drawing.Size(992, 471);
            this.dgvAgendas.TabIndex = 157;
            this.dgvAgendas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgendas_CellContentClick);
            this.dgvAgendas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAgendas_CellPainting);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label34.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label34.Location = new System.Drawing.Point(19, 24);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(237, 22);
            this.label34.TabIndex = 155;
            this.label34.Text = "Lista de Agenda Médica";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.lblHC);
            this.panel1.Controls.Add(this.lblEstado);
            this.panel1.Controls.Add(this.cboEstado);
            this.panel1.Controls.Add(this.btnHC);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Location = new System.Drawing.Point(13, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 42);
            this.panel1.TabIndex = 158;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblNombre.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.Gold;
            this.lblNombre.Location = new System.Drawing.Point(409, 11);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(12, 17);
            this.lblNombre.TabIndex = 306;
            this.lblNombre.Text = "-";
            this.lblNombre.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.IconChar = FontAwesome.Sharp.IconChar.ArrowTurnDown;
            this.btnAgregar.IconColor = System.Drawing.Color.Aqua;
            this.btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregar.IconSize = 25;
            this.btnAgregar.Location = new System.Drawing.Point(850, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(36, 32);
            this.btnAgregar.TabIndex = 326;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Visible = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblHC
            // 
            this.lblHC.AutoSize = true;
            this.lblHC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblHC.Location = new System.Drawing.Point(902, 9);
            this.lblHC.Name = "lblHC";
            this.lblHC.Size = new System.Drawing.Size(40, 17);
            this.lblHC.TabIndex = 325;
            this.lblHC.Text = "H.C.:";
            this.lblHC.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblEstado.Location = new System.Drawing.Point(635, 9);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 17);
            this.lblEstado.TabIndex = 324;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Visible = false;
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEstado.ForeColor = System.Drawing.Color.White;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "EN ESPERA",
            "ATENDIDO",
            "CONSULTORIO",
            "CANCELADO"});
            this.cboEstado.Location = new System.Drawing.Point(697, 6);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(145, 25);
            this.cboEstado.TabIndex = 323;
            this.cboEstado.Visible = false;
            // 
            // btnHC
            // 
            this.btnHC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnHC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHC.FlatAppearance.BorderSize = 0;
            this.btnHC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHC.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.btnHC.IconColor = System.Drawing.Color.Fuchsia;
            this.btnHC.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHC.IconSize = 30;
            this.btnHC.Location = new System.Drawing.Point(948, 5);
            this.btnHC.Name = "btnHC";
            this.btnHC.Size = new System.Drawing.Size(35, 30);
            this.btnHC.TabIndex = 306;
            this.btnHC.UseVisualStyleBackColor = false;
            this.btnHC.Visible = false;
            this.btnHC.Click += new System.EventHandler(this.btnHC_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.BorderColor = System.Drawing.Color.White;
            this.dtpFecha.BorderSize = 1;
            this.dtpFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(248, 6);
            this.dtpFecha.MinimumSize = new System.Drawing.Size(4, 23);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(155, 29);
            this.dtpFecha.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.dtpFecha.TabIndex = 322;
            this.dtpFecha.TextColor = System.Drawing.Color.Yellow;
            this.dtpFecha.CloseUp += new System.EventHandler(this.dtpFecha_CloseUp);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 25;
            // 
            // id_Plan
            // 
            this.id_Plan.HeaderText = "id";
            this.id_Plan.Name = "id_Plan";
            this.id_Plan.ReadOnly = true;
            this.id_Plan.Visible = false;
            // 
            // FecTurno
            // 
            this.FecTurno.HeaderText = "Fecha";
            this.FecTurno.Name = "FecTurno";
            this.FecTurno.ReadOnly = true;
            this.FecTurno.Visible = false;
            // 
            // Hora
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle3;
            this.Hora.HeaderText = "HH";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            this.Hora.Width = 30;
            // 
            // Minutos
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.Minutos.DefaultCellStyle = dataGridViewCellStyle4;
            this.Minutos.HeaderText = "MM";
            this.Minutos.Name = "Minutos";
            this.Minutos.ReadOnly = true;
            this.Minutos.Width = 30;
            // 
            // Turno
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Turno.DefaultCellStyle = dataGridViewCellStyle5;
            this.Turno.HeaderText = "ORD.";
            this.Turno.Name = "Turno";
            this.Turno.ReadOnly = true;
            this.Turno.Width = 50;
            // 
            // ApellidoyNombres
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ApellidoyNombres.DefaultCellStyle = dataGridViewCellStyle6;
            this.ApellidoyNombres.HeaderText = "APELLIDO Y NOMBRES";
            this.ApellidoyNombres.Name = "ApellidoyNombres";
            this.ApellidoyNombres.ReadOnly = true;
            this.ApellidoyNombres.Width = 300;
            // 
            // TipoEst
            // 
            this.TipoEst.HeaderText = "TIPO";
            this.TipoEst.Name = "TipoEst";
            this.TipoEst.ReadOnly = true;
            this.TipoEst.Width = 230;
            // 
            // Pacte
            // 
            this.Pacte.HeaderText = "Pacte";
            this.Pacte.Name = "Pacte";
            this.Pacte.ReadOnly = true;
            this.Pacte.Visible = false;
            // 
            // Numero
            // 
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            this.Numero.Visible = false;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "ESTADO";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // FecEstado
            // 
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.FecEstado.DefaultCellStyle = dataGridViewCellStyle7;
            this.FecEstado.HeaderText = "FecEstado";
            this.FecEstado.Name = "FecEstado";
            this.FecEstado.ReadOnly = true;
            this.FecEstado.Visible = false;
            // 
            // Obs
            // 
            this.Obs.HeaderText = "OBS";
            this.Obs.Name = "Obs";
            this.Obs.ReadOnly = true;
            this.Obs.Width = 160;
            // 
            // Profesional
            // 
            this.Profesional.HeaderText = "PROFESIONAL";
            this.Profesional.Name = "Profesional";
            this.Profesional.ReadOnly = true;
            this.Profesional.Width = 150;
            // 
            // UserRegistro
            // 
            this.UserRegistro.HeaderText = "UserRegistro";
            this.UserRegistro.Name = "UserRegistro";
            this.UserRegistro.ReadOnly = true;
            this.UserRegistro.Visible = false;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "FechaRegistro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            this.FechaRegistro.Visible = false;
            // 
            // frmVerAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1168, 580);
            this.Controls.Add(this.pnlDeck);
            this.Controls.Add(this.pnlTitulo);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVerAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISUALIZAR AGENDA MÉDICA";
            this.Load += new System.EventHandler(this.frmVerAgenda_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.pnlDeck.ResumeLayout(false);
            this.pnlDeck.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgendas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        public System.Windows.Forms.TextBox txtPaciente;
        public System.Windows.Forms.TextBox txtIndice;
        private System.Windows.Forms.TextBox txtFechaRegistro;
        public System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtUserRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlDeck;
        public System.Windows.Forms.TextBox txtNumeroDoc;
        public System.Windows.Forms.TextBox txtTipoDoc;
        public System.Windows.Forms.TextBox txtSexo;
        public System.Windows.Forms.TextBox txtFecNacim;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnClear;
        private System.Windows.Forms.DataGridView dgvAgendas;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Panel panel1;
        private DatePicker dtpFecha;
        private FontAwesome.Sharp.IconButton btnHC;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblHC;
        private System.Windows.Forms.Label lblEstado;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Minutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoyNombres;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoEst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pacte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FecEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Obs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
    }
}