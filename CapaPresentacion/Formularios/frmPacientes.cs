using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPacientes : Form
    {
        private string respuesta;
        int codpos = 0;
        public string localidad;

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Pacientes> ListaPac = new CN_Pacientes().ListaPacte();

            //***** CARGO EL DGV *****
            foreach (CE_Pacientes item in ListaPac)
            {
                dgvPacientes.Rows.Add(new object[] { "", item.id_Pacte, item.ApelNombres, item.FechaNacim, item.TipoDoc, item.NumeroDoc, item.Domicilio, item.CodPostal, item.Sexo,
                                                item.Telefono, item.Email, item.ObraSocial, item.PlanOS, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            //Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvPacientes.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtNumeroDoc.Select();
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvPacientes.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvPacientes.Rows[i].Cells["FecEstado"].Value);
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
            cboTipoDoc.Text = "DNI";
            txtNumeroDoc.Text = String.Empty;
            txtApelNombres.Text = String.Empty;
            cboSexo.Text = String.Empty;
            dtpFechaNacim.Value = DateTime.Now;
            txtDomicilio.Text = String.Empty;
            lblLocalidad.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboObraSocial.Text = String.Empty;
            cboPlanOS.Text = String.Empty;
            txtObs.Text = String.Empty;

            txtNumeroDoc.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvPacientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvPacientes.Rows[indice].Cells["id_Prof"].Value.ToString();
                    cboTipoDoc.Text = dgvPacientes.Rows[indice].Cells["TipoDoc"].Value.ToString();
                    txtNumeroDoc.Text = dgvPacientes.Rows[indice].Cells["NumeroDoc"].Value.ToString();
                    txtApelNombres.Text = dgvPacientes.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                    cboSexo.Text = dgvPacientes.Rows[indice].Cells["Sexo"].Value.ToString();
                    dtpFechaNacim.Value = Convert.ToDateTime(dgvPacientes.Rows[indice].Cells["Fecha"].Value.ToString());
                    txtDomicilio.Text = dgvPacientes.Rows[indice].Cells["Domicilio"].Value.ToString();
                    txtCodPos.Text = dgvPacientes.Rows[indice].Cells["CodigoPostal"].Value.ToString();

                    //***** BUSCO LA LOCALIDAD DEL PACIENTE *****
                    codpos = Convert.ToInt32(txtCodPos.Text);
                    localidad = new CN_CodigosPostales().BuscaCodPos(codpos);
                    lblLocalidad.Text = localidad.ToString();

                    txtEmail.Text = dgvPacientes.Rows[indice].Cells["Email"].Value.ToString();
                    cboObraSocial.Text = dgvPacientes.Rows[indice].Cells["Estado"].Value.ToString();
                    cboPlanOS.Text = dgvPacientes.Rows[indice].Cells["Estado"].Value.ToString();
                    txtObs.Text = dgvPacientes.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvPacientes.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvPacientes.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvPacientes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPacientes.Rows)
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
            foreach (DataGridViewRow row in dgvPacientes.Rows)
            {
                row.Visible = true;
            }
        }

        //***** PROCEDIMIENTO DEL BOTON PARA BUSCAR LA LOCALIDAD *****
        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            mdlCodPostal CodigoPostal = new mdlCodPostal("btnLocalidad");
            AddOwnedForm(CodigoPostal);
            CodigoPostal.ShowDialog();
        }



    }
}
