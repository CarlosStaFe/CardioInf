
namespace CapaPresentacion.Formularios
{
    partial class ControlDia
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDia = new System.Windows.Forms.Label();
            this.lblDetalle2 = new System.Windows.Forms.Label();
            this.lblDetalle3 = new System.Windows.Forms.Label();
            this.lblDetalle1 = new System.Windows.Forms.Label();
            this.lblDoctor3 = new System.Windows.Forms.Label();
            this.lblDoctor2 = new System.Windows.Forms.Label();
            this.lblDoctor1 = new System.Windows.Forms.Label();
            this.btn1 = new FontAwesome.Sharp.IconButton();
            this.btn2 = new FontAwesome.Sharp.IconButton();
            this.btn3 = new FontAwesome.Sharp.IconButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtDoctor1 = new System.Windows.Forms.TextBox();
            this.txtDoctor2 = new System.Windows.Forms.TextBox();
            this.txtDoctor3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblDia
            // 
            this.lblDia.AutoSize = true;
            this.lblDia.BackColor = System.Drawing.Color.Silver;
            this.lblDia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDia.ForeColor = System.Drawing.Color.Black;
            this.lblDia.Location = new System.Drawing.Point(3, 2);
            this.lblDia.Margin = new System.Windows.Forms.Padding(0);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(26, 18);
            this.lblDia.TabIndex = 0;
            this.lblDia.Text = "00";
            this.lblDia.Click += new System.EventHandler(this.lblDia_Click);
            // 
            // lblDetalle2
            // 
            this.lblDetalle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDetalle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle2.ForeColor = System.Drawing.Color.White;
            this.lblDetalle2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle2.Location = new System.Drawing.Point(5, 52);
            this.lblDetalle2.Name = "lblDetalle2";
            this.lblDetalle2.Size = new System.Drawing.Size(142, 13);
            this.lblDetalle2.TabIndex = 2;
            this.lblDetalle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle2.Visible = false;
            // 
            // lblDetalle3
            // 
            this.lblDetalle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDetalle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle3.ForeColor = System.Drawing.Color.White;
            this.lblDetalle3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle3.Location = new System.Drawing.Point(5, 82);
            this.lblDetalle3.Name = "lblDetalle3";
            this.lblDetalle3.Size = new System.Drawing.Size(142, 13);
            this.lblDetalle3.TabIndex = 3;
            this.lblDetalle3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle3.Visible = false;
            // 
            // lblDetalle1
            // 
            this.lblDetalle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDetalle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle1.ForeColor = System.Drawing.Color.White;
            this.lblDetalle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle1.Location = new System.Drawing.Point(5, 22);
            this.lblDetalle1.Name = "lblDetalle1";
            this.lblDetalle1.Size = new System.Drawing.Size(142, 13);
            this.lblDetalle1.TabIndex = 1;
            this.lblDetalle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetalle1.Visible = false;
            // 
            // lblDoctor3
            // 
            this.lblDoctor3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDoctor3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDoctor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctor3.ForeColor = System.Drawing.Color.White;
            this.lblDoctor3.Location = new System.Drawing.Point(25, 68);
            this.lblDoctor3.Name = "lblDoctor3";
            this.lblDoctor3.Size = new System.Drawing.Size(121, 13);
            this.lblDoctor3.TabIndex = 4;
            this.lblDoctor3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoctor3.Visible = false;
            this.lblDoctor3.Click += new System.EventHandler(this.lblDoctor3_Click);
            // 
            // lblDoctor2
            // 
            this.lblDoctor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDoctor2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDoctor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctor2.ForeColor = System.Drawing.Color.White;
            this.lblDoctor2.Location = new System.Drawing.Point(25, 38);
            this.lblDoctor2.Name = "lblDoctor2";
            this.lblDoctor2.Size = new System.Drawing.Size(121, 13);
            this.lblDoctor2.TabIndex = 5;
            this.lblDoctor2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoctor2.Visible = false;
            this.lblDoctor2.Click += new System.EventHandler(this.lblDoctor2_Click);
            // 
            // lblDoctor1
            // 
            this.lblDoctor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblDoctor1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDoctor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctor1.ForeColor = System.Drawing.Color.White;
            this.lblDoctor1.Location = new System.Drawing.Point(25, 8);
            this.lblDoctor1.Name = "lblDoctor1";
            this.lblDoctor1.Size = new System.Drawing.Size(121, 13);
            this.lblDoctor1.TabIndex = 6;
            this.lblDoctor1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoctor1.Visible = false;
            this.lblDoctor1.Click += new System.EventHandler(this.lblDoctor1_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btn1.IconColor = System.Drawing.Color.White;
            this.btn1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn1.IconSize = 12;
            this.btn1.Location = new System.Drawing.Point(132, 20);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(14, 14);
            this.btn1.TabIndex = 7;
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Visible = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btn2.IconColor = System.Drawing.Color.White;
            this.btn2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn2.IconSize = 12;
            this.btn2.Location = new System.Drawing.Point(132, 50);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(14, 14);
            this.btn2.TabIndex = 8;
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Visible = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btn3.IconColor = System.Drawing.Color.White;
            this.btn3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn3.IconSize = 12;
            this.btn3.Location = new System.Drawing.Point(132, 80);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(14, 14);
            this.btn3.TabIndex = 9;
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Visible = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtDoctor1
            // 
            this.txtDoctor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor1.Location = new System.Drawing.Point(6, 1);
            this.txtDoctor1.Name = "txtDoctor1";
            this.txtDoctor1.Size = new System.Drawing.Size(17, 20);
            this.txtDoctor1.TabIndex = 10;
            this.txtDoctor1.Visible = false;
            // 
            // txtDoctor2
            // 
            this.txtDoctor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor2.Location = new System.Drawing.Point(6, 32);
            this.txtDoctor2.Name = "txtDoctor2";
            this.txtDoctor2.Size = new System.Drawing.Size(17, 20);
            this.txtDoctor2.TabIndex = 11;
            this.txtDoctor2.Visible = false;
            // 
            // txtDoctor3
            // 
            this.txtDoctor3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoctor3.Location = new System.Drawing.Point(6, 61);
            this.txtDoctor3.Name = "txtDoctor3";
            this.txtDoctor3.Size = new System.Drawing.Size(17, 20);
            this.txtDoctor3.TabIndex = 12;
            this.txtDoctor3.Visible = false;
            // 
            // ControlDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtDoctor3);
            this.Controls.Add(this.txtDoctor2);
            this.Controls.Add(this.txtDoctor1);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.lblDoctor1);
            this.Controls.Add(this.lblDoctor2);
            this.Controls.Add(this.lblDoctor3);
            this.Controls.Add(this.lblDetalle3);
            this.Controls.Add(this.lblDetalle2);
            this.Controls.Add(this.lblDetalle1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlDia";
            this.Size = new System.Drawing.Size(150, 100);
            this.Load += new System.EventHandler(this.ControlDia_Load);
            this.Click += new System.EventHandler(this.ControlDia_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.Label lblDetalle2;
        private System.Windows.Forms.Label lblDetalle3;
        private System.Windows.Forms.Label lblDetalle1;
        private System.Windows.Forms.Label lblDoctor3;
        private System.Windows.Forms.Label lblDoctor2;
        private System.Windows.Forms.Label lblDoctor1;
        private FontAwesome.Sharp.IconButton btn1;
        private FontAwesome.Sharp.IconButton btn2;
        private FontAwesome.Sharp.IconButton btn3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtDoctor1;
        private System.Windows.Forms.TextBox txtDoctor2;
        private System.Windows.Forms.TextBox txtDoctor3;
    }
}
