using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmObrasSociales : Form
    {
        private string respuesta;
        int codpos = 0;
        public string localidad;
        SoloNumeros validar = new SoloNumeros();

        public frmObrasSociales()
        {
            InitializeComponent();
        }

        private void frmObrasSociales_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_ObrasSociales> ListaOS = new CN_ObrasSociales().ListaOS();

            //***** CARGO EL DGV *****
            foreach (CE_ObrasSociales item in ListaOS)
            {
                dgvObrasSociales.Rows.Add(new object[] { "", item.id_OS, item.Nombre, item.Cuit, item.Domicilio, item.CodPostal, item.Telefono, item.Email, item.Obs,
                                                item.UserRegistro, item.FechaRegistro });
            }

            //Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvObrasSociales.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtNombre.Select();
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvObrasSociales.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvObrasSociales.Rows[i].Cells["FecEstado"].Value);
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
            txtNombre.Text = String.Empty;
            txtCuit.Text = String.Empty;
            txtDomicilio.Text = String.Empty;
            lblLocalidad.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtObs.Text = String.Empty;

            txtNombre.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvObrasSociales_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvObrasSociales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvObrasSociales.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvObrasSociales.Rows[indice].Cells["id_OS"].Value.ToString();
                    txtNombre.Text = dgvObrasSociales.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtCuit.Text = dgvObrasSociales.Rows[indice].Cells["Cuit"].Value.ToString();
                    txtDomicilio.Text = dgvObrasSociales.Rows[indice].Cells["Domicilio"].Value.ToString();
                    txtTelefono.Text = dgvObrasSociales.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtCodPos.Text = dgvObrasSociales.Rows[indice].Cells["CodPostal"].Value.ToString();

                    //***** BUSCO LA LOCALIDAD DEL PACIENTE *****
                    codpos = Convert.ToInt32(txtCodPos.Text);
                    localidad = new CN_CodigosPostales().BuscaCodPos(codpos);
                    lblLocalidad.Text = localidad.ToString();

                    txtEmail.Text = dgvObrasSociales.Rows[indice].Cells["Email"].Value.ToString();
                    txtObs.Text = dgvObrasSociales.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvObrasSociales.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvObrasSociales.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvObrasSociales.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvObrasSociales.Rows)
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
            foreach (DataGridViewRow row in dgvObrasSociales.Rows)
            {
                row.Visible = true;
            }
        }

        //***** PROCEDIMIENTO DEL BOTON PARA BUSCAR LA LOCALIDAD *****
        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            mdlCodPostal CodigoPostal = new mdlCodPostal("btnLocalOS");
            AddOwnedForm(CodigoPostal);
            CodigoPostal.ShowDialog();
        }

        //***** PROCEDIMIENTO DEL BOTON GUARDAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTA OBRA SOCIAL...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_ObrasSociales cE_ObrasSociales = new CE_ObrasSociales()
                {
                    id_OS = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Cuit = txtCuit.Text,
                    Domicilio = txtDomicilio.Text,
                    CodPostal = Convert.ToInt32(txtCodPos.Text),
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Now
                };

                //*****SI EL ID DE LA OBRA SOCIAL = 0 REGISTRA, SINO EDITA *****
                if (cE_ObrasSociales.id_OS == 0)
                {
                    int idOS = new CN_ObrasSociales().Registrar(cE_ObrasSociales, out mensaje);

                    if (idOS != 0)
                    {
                        dgvObrasSociales.Rows.Add(new object[] {"",idOS,txtNombre.Text,txtCuit.Text,txtDomicilio.Text,txtCodPos.Text,
                                                  txtTelefono.Text,txtEmail.Text,txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text});
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
                    bool resultado = new CN_ObrasSociales().Editar(cE_ObrasSociales, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvObrasSociales.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_OS"].Value = txtId.Text;
                        row.Cells["Nombre"].Value = txtNombre.Text;
                        row.Cells["Cuit"].Value = txtCuit.Text;
                        row.Cells["Domicilio"].Value = txtDomicilio.Text;
                        row.Cells["CodPostal"].Value = Convert.ToInt32(txtCodPos.Text);
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["Email"].Value = txtEmail.Text;
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

        //***** VALIDO SI ES SOLO NÚMEROS *****
        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }
    }
}
