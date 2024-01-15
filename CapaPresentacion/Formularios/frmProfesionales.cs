using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmProfesionales : Form
    {
        private string respuesta;

        public frmProfesionales()
        {
            InitializeComponent();
        }

        private void frmProfesionales_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargarCombo();

            List<CE_Profesionales> ListaProf = new CN_Profesionales().ListaProf();

            //***** CARGO EL DGV *****
            foreach (CE_Profesionales item in ListaProf)
            {
                dgvProfesionales.Rows.Add(new object[] { "", item.id_Prof, item.Matricula, item.ApelNombres, item.Usuario, item.TipoDoc, item.NumeroDoc, item.Sexo, item.Telefono, item.Email, item.Estado,
                                                item.FechaEstado, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvProfesionales.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtMatricula.Select();

        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvProfesionales.Rows.Count; i++)
            {
                //DateTime dateFecha = Convert.ToDateTime(dgvProfesionales.Rows[i].Cells["FecEstado"].Value);
            }
        }

        //***** SI EL ID DEL PROFESIONAL = 0 REGISTRA, SINO EDITA *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE PROFESIONAL...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Profesionales cE_Profesionales = new CE_Profesionales()
                {
                    id_Prof = Convert.ToInt32(txtId.Text),
                    Matricula = Convert.ToInt32(txtMatricula.Text),
                    ApelNombres = txtApelNombres.Text,
                    Usuario = cboUsuarios.Text,
                    TipoDoc = cboTipoDoc.Text,
                    NumeroDoc = Convert.ToInt32(txtNumeroDoc.Text),
                    Sexo = cboSexo.Text,
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Estado = cboEstado.Text,
                    FechaEstado = dtpFecEstado.Value,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //***** SI EL ID DEL PROFESIONALES = 0 REGISTRA, SINO EDITA *****
                if (cE_Profesionales.id_Prof == 0)
                {
                    int idProfesional = new CN_Profesionales().Registrar(cE_Profesionales, out mensaje);

                    if (idProfesional != 0)
                    {
                        dgvProfesionales.Rows.Add(new object[] {"",idProfesional,txtMatricula.Text,txtApelNombres.Text,cboUsuarios.Text,cboTipoDoc.Text,txtNumeroDoc.Text,cboSexo.Text,
                                                  txtTelefono.Text,txtEmail.Text,cboEstado.Text,dtpFecEstado.Value,txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text});
                        Limpiar();
                    }
                    else
                    {
                        mensaje += ". VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
                else
                {
                    bool resultado = new CN_Profesionales().Editar(cE_Profesionales, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvProfesionales.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Prof"].Value = txtIndice.Text;
                        row.Cells["Matri"].Value = txtMatricula.Text;
                        row.Cells["ApellidoyNombres"].Value = txtApelNombres.Text;
                        row.Cells["Usuario"].Value = cboUsuarios.Text;
                        row.Cells["Tipo"].Value = cboTipoDoc.Text;
                        row.Cells["Numero"].Value = txtNumeroDoc.Text;
                        row.Cells["Sexo"].Value = cboSexo.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["Email"].Value = txtEmail.Text;
                        row.Cells["Estado"].Value = cboEstado.Text;
                        row.Cells["Fecha"].Value = dtpFecEstado.Value;
                        row.Cells["Obs"].Value = txtObs.Text;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;
                        row.Cells["FechaRegistro"].Value = txtFechaRegistro.Text;

                        Limpiar();
                    }
                    else
                    {
                        mensaje += ". VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            txtId.Text = "0";
            txtMatricula.Text = String.Empty;
            cboUsuarios.Text = String.Empty;
            txtApelNombres.Text = String.Empty;
            cboTipoDoc.Text = String.Empty;
            txtNumeroDoc.Text = String.Empty;
            cboSexo.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboEstado.Text = String.Empty;
            txtObs.Text = String.Empty;
            dtpFecEstado.Value = DateTime.Now;

            txtMatricula.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvProfesionales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //***** MUEVO LO SELECCIONADO DEL DGV A LOS CAMPOS PARA MODIFICAR *****
        private void dgvProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProfesionales.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvProfesionales.Rows[indice].Cells["id_Prof"].Value.ToString();
                    txtMatricula.Text = dgvProfesionales.Rows[indice].Cells["Matri"].Value.ToString();
                    txtMatricula.Text = txtMatricula.Text;

                    int numero = int.Parse(txtMatricula.Text);

                    txtApelNombres.Text = dgvProfesionales.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                    cboUsuarios.Text = dgvProfesionales.Rows[indice].Cells["Usuario"].Value.ToString();
                    cboTipoDoc.Text = dgvProfesionales.Rows[indice].Cells["Tipo"].Value.ToString();
                    txtNumeroDoc.Text = dgvProfesionales.Rows[indice].Cells["Numero"].Value.ToString();
                    txtTelefono.Text = dgvProfesionales.Rows[indice].Cells["Telefono"].Value.ToString();
                    cboSexo.Text = dgvProfesionales.Rows[indice].Cells["Sexo"].Value.ToString();
                    txtEmail.Text = dgvProfesionales.Rows[indice].Cells["Email"].Value.ToString();
                    cboEstado.Text = dgvProfesionales.Rows[indice].Cells["Estado"].Value.ToString();
                    dtpFecEstado.Value = Convert.ToDateTime(dgvProfesionales.Rows[indice].Cells["Fecha"].Value.ToString());
                    txtObs.Text = dgvProfesionales.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvProfesionales.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvProfesionales.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvProfesionales.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvProfesionales.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvProfesionales.Rows)
            {
                row.Visible = true;
            }
        }

        //***** CARGO LOS COMBOS DE CADA ESTUDIO *****
        private void CargarCombo()
        {
            List<CE_Usuarios> ListaUser = new CN_Usuarios().ListaUser();

            foreach (CE_Usuarios item in ListaUser)
            {
                cboUsuarios.Items.Add(item.Usuario);
                cboUsuarios.SelectedIndex = -1;
            }
        }

        //***** CARGO EL COMBO DE LOS USUARIOS DEL SISTEMA *****
        private void CargarCboUser()
        {
            cboUsuarios.Items.Clear();
            cboUsuarios.Text = string.Empty;

            List<CE_Usuarios> ListaUser = new CN_Usuarios().ListaUser();

            foreach (CE_Usuarios item in ListaUser)
            {
                cboUsuarios.Items.Add(item.Usuario);
                cboUsuarios.SelectedIndex = -1;
            }
        }
    }
}
