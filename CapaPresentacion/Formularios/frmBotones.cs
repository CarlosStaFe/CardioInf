using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmBotones : Form
    {
        CN_Botones cN_Botones = new CN_Botones();
        private string respuesta;

        public frmBotones()
        {
            InitializeComponent();
        }

        private void frmBotones_Load(object sender, EventArgs e)
        {
            List<CE_Botones> ListaBoton = new CN_Botones().ListaBoton();

            //***** CARGO EL DGV *****
            foreach (CE_Botones item in ListaBoton)
            {
                dgvBotones.Rows.Add(new object[] { "", item.id_Boton, item.Nombre, item.Detalle, item.UserRegistro });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvBotones.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtNombre.Select();
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE BOTÓN...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Botones cEBotones = new CE_Botones()
                {
                    id_Boton = Convert.ToInt32(txtId.Text),
                    Nombre = txtNombre.Text,
                    Detalle = txtDetalle.Text,
                    UserRegistro = VarGlobales.NombreUsuario
                };

                //***** SI EL ID DEL BOTÓN = 0 REGISTRA, SINO EDITA *****
                if (cEBotones.id_Boton == 0)
                {
                    int idBoton = new CN_Botones().Registrar(cEBotones, out mensaje);

                    if (idBoton != 0)
                    {
                        dgvBotones.Rows.Add(new object[] { "", idBoton, txtNombre.Text, txtDetalle.Text, txtUserRegistro.Text });
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
                    bool resultado = new CN_Botones().Editar(cEBotones, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvBotones.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Boton"].Value = txtIndice.Text;
                        row.Cells["Nombre"].Value = txtNombre.Text;
                        row.Cells["Detalle"].Value = txtDetalle.Text;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;

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

        //***** PROCEDIMIENTO DEL BOTON ELIMINAR *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (Convert.ToInt32(txtId.Text) != 0)
            {
                mensaje += "DESEA ELIMINAR ESTE BOTÓN...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();

                if (respuesta == "OK")
                {
                    CE_Botones cEBotones = new CE_Botones()
                    {
                        id_Boton = Convert.ToInt32(txtId.Text),
                    };

                    bool resultado = new CN_Botones().Eliminar(cEBotones, out mensaje);

                    if (resultado)
                    {
                        dgvBotones.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
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
            txtNombre.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            txtUserRegistro.Text = string.Empty;
            txtNombre.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvBotones_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvBotones_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBotones.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvBotones.Rows[indice].Cells["id_Boton"].Value.ToString();
                    txtNombre.Text = dgvBotones.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtDetalle.Text = dgvBotones.Rows[indice].Cells["Detalle"].Value.ToString();
                    txtUserRegistro.Text = dgvBotones.Rows[indice].Cells["UserRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cboBusqueda.SelectedItem.ToString();

            if (dgvBotones.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvBotones.Rows)
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
            foreach (DataGridViewRow row in dgvBotones.Rows)
            {
                row.Visible = true;
            }
        }

    }
}
