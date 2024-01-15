using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class frmPlanesOS : Form
    {
        private string respuesta;

        public frmPlanesOS()
        {
            InitializeComponent();
        }

        private void frmPlanesOS_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargarCombos();

            List<CE_PlanesOS> ListaPlanes = new CN_PlanesOS().ListaPlanes();

            //***** CARGO EL DGV *****
            foreach (CE_PlanesOS item in ListaPlanes)
            {
                dgvPlanes.Rows.Add(new object[] { "", item.id_Plan, item.OSPlan, item.NombrePlan, item.Estado, item.FechaEstado, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvPlanes.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvPlanes.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvPlanes.Rows[i].Cells["FecEstado"].Value);
            }
        }

        //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE PLAN...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_PlanesOS cE_PlanesOS = new CE_PlanesOS()
                {
                    id_Plan = Convert.ToInt32(txtId.Text),
                    OSPlan = cboObraSocial.Text,
                    NombrePlan = txtPlan.Text,
                    Estado = cboEstado.Text,
                    FechaEstado = DateTime.Now,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
                if (cE_PlanesOS.id_Plan == 0)
                {
                    int idPlan = new CN_PlanesOS().Registrar(cE_PlanesOS, out mensaje);

                    if (idPlan != 0)
                    {
                        dgvPlanes.Rows.Add(new object[] { "", idPlan, cboObraSocial.Text, txtPlan.Text, cboEstado.Text, txtFechaRegistro.Text, txtObs.Text, txtUserRegistro.Text, txtFechaRegistro.Text });
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
                    bool resultado = new CN_PlanesOS().Editar(cE_PlanesOS, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvPlanes.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Plan"].Value = txtId.Text;
                        row.Cells["OSPLan"].Value = cboObraSocial.Text;
                        row.Cells["NombrePlan"].Value = txtPlan.Text;
                        row.Cells["Estado"].Value = cboEstado.Text;
                        row.Cells["FecEstado"].Value = DateTime.Now;
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
            txtIndice.Text = "0";
            cboObraSocial.Text = String.Empty;
            txtPlan.Text = String.Empty;
            cboEstado.Text = String.Empty;
            txtObs.Text = String.Empty;

            cboObraSocial.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvPlanes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanes.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvPlanes.Rows[indice].Cells["id_Plan"].Value.ToString();
                    cboObraSocial.Text = dgvPlanes.Rows[indice].Cells["OSPlan"].Value.ToString();
                    txtPlan.Text = dgvPlanes.Rows[indice].Cells["NombrePlan"].Value.ToString();
                    cboEstado.Text = dgvPlanes.Rows[indice].Cells["Estado"].Value.ToString();
                    txtObs.Text = dgvPlanes.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvPlanes.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvPlanes.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvPlanes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPlanes.Rows)
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
            foreach (DataGridViewRow row in dgvPlanes.Rows)
            {
                row.Visible = true;
            }
        }

        //***** CARGO EL COMBO DE LAS OBRAS SOCIALES *****
        private void CargarCombos()
        {
            cboObraSocial.Items.Clear();
            cboObraSocial.Text = string.Empty;

            List<CE_ObrasSociales> ListaOS = new CN_ObrasSociales().ListaOS();

            foreach (CE_ObrasSociales item in ListaOS)
            {
                cboObraSocial.Items.Add(item.Nombre);
                cboObraSocial.SelectedIndex = -1;             
            }
        }
    }
}
