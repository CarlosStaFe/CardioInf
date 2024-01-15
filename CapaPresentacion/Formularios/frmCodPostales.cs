using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class frmCodPostales : Form
    {
        CN_CodigosPostales cN_CodigosPostales = new CN_CodigosPostales();
        CN_Localidades cN_Localidades = new CN_Localidades();
        private string respuesta;

        public frmCodPostales()
        {
            InitializeComponent();
        }

        private void frmCodPostales_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            Limpiar();

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

            txtCodigo.Select();
        }

        //***** CARGO EL COMBO DE LOCALIDADES *****
        private void CargoCboLocalidad()
        {
            List<CE_Localidades> ListaLocal = new CN_Localidades().ListaLocal();

            cboLocalidad.Items.Clear();
            cboLocalidad.DataSource = ListaLocal;
            cboLocalidad.DisplayMember = "Localidad";
            cboLocalidad.ValueMember = "id_Local";
        }

        //***** CARGO EL COMBO DE DEPARTAMENTOS *****
        private void CargoCboDeptos()
        {
            List<CE_Departamentos> ListaDeptos = new CN_Departamentos().ListaDeptos();

            cboDepartamento.Items.Clear();
            cboDepartamento.DataSource = ListaDeptos;
            cboDepartamento.DisplayMember = "Departamento";
            cboDepartamento.ValueMember = "id_Depto";
        }

        //***** CARGO EL COMBO DE PROVINCIAS *****
        private void CargoCboProvincias()
        {
            List<CE_Provincias> ListaProvincias = new CN_Provincias().ListaProvincias();

            cboProvincia.Items.Clear();
            cboProvincia.DataSource = ListaProvincias;
            cboProvincia.DisplayMember = "Provincia";
            cboProvincia.ValueMember = "id_Prov";
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, System.EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE CÓDIGO POSTAL...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_CodigosPostales cE_CodigosPostales = new CE_CodigosPostales()
                {
                    id_CodPos = Convert.ToInt32(txtId.Text),
                    fk_Local = Convert.ToInt32(cboLocalidad.SelectedValue),
                    fk_Depto = Convert.ToInt32(cboDepartamento.SelectedValue),
                    fk_Prov = Convert.ToInt32(cboProvincia.SelectedValue),
                    CodigoPostal = Convert.ToInt32(txtCodigo.Text),
                    Localidad = txtLocalidad.Text,
                    UserRegistro = CE_UserLogin.Usuario
                };

                //if (txtLocalidad.Text != "") cE_CodigosPostales.id_CodPos = 0;

                //***** SI EL ID DEL CODIGO POSTAL = 0 REGISTRA, SINO EDITA *****
                if (cE_CodigosPostales.id_CodPos == 0)
                {
                    int idCodPos = new CN_CodigosPostales().Registrar(cE_CodigosPostales, out mensaje);
                    
                    if (txtLocalidad.Text != "")
                    {
                        CE_Localidades cE_Localidades = new CE_Localidades()
                        {
                            fk_Depto = Convert.ToInt32(cboDepartamento.SelectedValue),
                            fk_Prov = Convert.ToInt32(cboProvincia.SelectedValue),
                            Localidad = txtLocalidad.Text,
                            UserRegistro = CE_UserLogin.Usuario
                        };

                        cboLocalidad.Text = txtLocalidad.Text;
                        int idLocal = new CN_Localidades().Registrar(cE_Localidades, out mensaje);
                    }

                    if (idCodPos != 0)
                    {
                        dgvCodPostales.Rows.Add(new object[] {"",idCodPos,txtFkLocal.Text,txtFkDepto.Text,txtFkProv.Text,txtCodigo,txtLocalidad.Text,txtUserRegistro.Text});
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
                    bool resultado = new CN_CodigosPostales().Editar(cE_CodigosPostales, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvCodPostales.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Local"].Value = txtIndice.Text;
                        row.Cells["fk_Local"].Value = txtFkLocal.Text;
                        row.Cells["fk_Deptos"].Value = txtFkDepto.Text;
                        row.Cells["fk_Prov"].Value = txtFkProv.Text;
                        row.Cells["Codigo"].Value = txtCodigo.Text;
                        row.Cells["Localidad"].Value = txtLocalidad.Text;
                        row.Cells["Departamento"].Value = cboDepartamento.Text;
                        row.Cells["Provincia"].Value = cboProvincia.Text;

                        Limpiar();
                    }
                    else
                    {
                        mensaje += "VERIFIQUE...!!!";
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
            CargoCboLocalidad();
            CargoCboDeptos();
            CargoCboProvincias();

            txtId.Text = "0";
            txtFkLocal.Text = "0";
            txtFkDepto.Text = "0";
            txtFkProv.Text = "0";
            txtCodigo.Text = string.Empty;
            txtLocalidad.Text = string.Empty;
            cboLocalidad.Text = string.Empty;
            cboDepartamento.Text = string.Empty;
            cboProvincia.Text = string.Empty;
            txtCodigo.Select();
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
                    txtId.Text = dgvCodPostales.Rows[indice].Cells["id_Local"].Value.ToString();
                    txtFkLocal.Text = dgvCodPostales.Rows[indice].Cells["fk_Local"].Value.ToString();
                    txtFkDepto.Text = dgvCodPostales.Rows[indice].Cells["fk_Deptos"].Value.ToString();
                    txtFkProv.Text = dgvCodPostales.Rows[indice].Cells["fk_Prov"].Value.ToString();
                    txtCodigo.Text = dgvCodPostales.Rows[indice].Cells["Codigo"].Value.ToString();
                    cboLocalidad.Text = dgvCodPostales.Rows[indice].Cells["Localidad"].Value.ToString();
                    cboDepartamento.Text = dgvCodPostales.Rows[indice].Cells["Departamento"].Value.ToString();
                    cboProvincia.Text = dgvCodPostales.Rows[indice].Cells["Provincia"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cboBusqueda.SelectedItem.ToString();

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

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
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
