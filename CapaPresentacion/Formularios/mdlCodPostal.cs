using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Formularios;

namespace CapaPresentacion
{
    public partial class mdlCodPostal : Form
    {
        CN_CodigosPostales cN_CodigosPostales = new CN_CodigosPostales();

        string NombreBoton;

        public mdlCodPostal(string NombreBoton)
        {
            InitializeComponent();
            this.NombreBoton = NombreBoton;
        }

        private void frmQueryCodPostal_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_CodigosPostales> ListaCodPos = new CN_CodigosPostales().ListaCodPos();

            //*****CARGO EL DGV *****
            foreach (CE_CodigosPostales item in ListaCodPos)
            {
                dgvCodPostales.Rows.Add(new object[] { "", item.id_CodPos,item.fk_Local, item.fk_Depto, item.fk_Prov, item.CodigoPostal, item.Localidad, item.Departamento, item.Provincia });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvCodPostales.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            cboBusqueda.Select();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvCodPostales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvCodPostales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCodPostales.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtIdCodPos.Text = dgvCodPostales.Rows[indice].Cells["id_Local"].Value.ToString();
                    txtFkLocal.Text = dgvCodPostales.Rows[indice].Cells["fk_Local"].Value.ToString();
                    txtFkDepto.Text = dgvCodPostales.Rows[indice].Cells["fk_Depto"].Value.ToString();
                    txtFkProv.Text = dgvCodPostales.Rows[indice].Cells["fk_Prov"].Value.ToString();
                    txtCodigo.Text = dgvCodPostales.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtLocalidad.Text = dgvCodPostales.Rows[indice].Cells["Localidad"].Value.ToString();
                    txtDepartamento.Text = dgvCodPostales.Rows[indice].Cells["Departamento"].Value.ToString();
                    txtProvincia.Text = dgvCodPostales.Rows[indice].Cells["Provincia"].Value.ToString();

                    if (NombreBoton == "btnLocalPacte")
                    {
                        frmPacientes DomPaciente = Owner as frmPacientes;
                        DomPaciente.lblLocalidad.Text = txtCodigo.Text + " - " + txtLocalidad.Text + " - " + txtDepartamento.Text + " - " + txtProvincia.Text;
                        DomPaciente.txtCodPos.Text = txtIdCodPos.Text;
                        Close();
                        Dispose();
                    }
                    if (NombreBoton == "btnLocalOS")
                    {
                        frmObrasSociales DomOS = Owner as frmObrasSociales;
                        DomOS.lblLocalidad.Text = txtCodigo.Text + " - " + txtLocalidad.Text + " - " + txtDepartamento.Text + " - " + txtProvincia.Text;
                        DomOS.txtCodPos.Text = txtIdCodPos.Text;
                        Close();
                        Dispose();
                    }
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvCodPostales.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvCodPostales.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtFiltro.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        //*****BUSCO Y CARGO LA FOTO DEL MATRICULADO *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cboBusqueda.Text = string.Empty;
            foreach (DataGridViewRow row in dgvCodPostales.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
