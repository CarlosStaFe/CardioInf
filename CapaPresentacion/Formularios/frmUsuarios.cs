using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmUsuarios : Form
    {
        CN_Usuarios cN_Usuarios = new CN_Usuarios();
        private string respuesta;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Usuarios> ListaUser = new CN_Usuarios().ListaUser();

            //*****CARGO EL DGV *****
            foreach (CE_Usuarios item in ListaUser)
            {
                dgvUsuarios.Rows.Add(new object[] { "", item.id_Usuario, item.Apellido, item.Nombres, item.Nivel, item.Funcion, item.Usuario, item.Clave, item.Activo, item.UserRegistro });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvUsuarios.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            txtApellido.Select();
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE USUARIO...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Usuarios cE_Usuarios = new CE_Usuarios()
                {
                    id_Usuario = Convert.ToInt32(txtId.Text),
                    Apellido = txtApellido.Text,
                    Nombres = txtNombres.Text,
                    Nivel = (int)nudNivel.Value,
                    Funcion = cboFuncion.Text,
                    Usuario = txtUsuario.Text,
                    Clave = txtClave.Text,
                    Activo = chbActivo.Checked,
                    UserRegistro = CE_UserLogin.Usuario
                };

                //*****SI EL ID DEL USUARIO = 0 REGISTRA, SINO EDITA *****
                if (cE_Usuarios.id_Usuario == 0)
                {
                    int idUsuario = new CN_Usuarios().Registrar(cE_Usuarios, out mensaje);

                    if (idUsuario != 0)
                    {
                        dgvUsuarios.Rows.Add(new object[] {"",idUsuario,txtApellido.Text,txtNombres.Text,nudNivel.Value,cboFuncion.Text,
                                                  txtUsuario.Text,txtClave.Text,chbActivo.Checked,txtUserRegistro.Text});
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
                    bool resultado = new CN_Usuarios().Editar(cE_Usuarios, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvUsuarios.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Usuario"].Value = txtIndice.Text;
                        row.Cells["Apellido"].Value = txtApellido.Text;
                        row.Cells["Nombres"].Value = txtNombres.Text;
                        row.Cells["Nivel"].Value = nudNivel.Value;
                        row.Cells["Funcion"].Value = cboFuncion.Text;
                        row.Cells["Usuario"].Value = txtUsuario.Text;
                        row.Cells["Clave"].Value = txtClave.Text;
                        row.Cells["Activo"].Value = chbActivo.Checked;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;

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

        //***** PROCEDIMIENTO DEL BOTON ELIMINAR *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (Convert.ToInt32(txtId.Text) != 0)
            {
                mensaje += "DESEA ELIMINAR ESTE USUARIO...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();

                if (respuesta == "OK")
                {
                    CE_Usuarios cEUsuarios = new CE_Usuarios()
                    {
                        id_Usuario = Convert.ToInt32(txtId.Text),
                    };

                    bool resultado = new CN_Usuarios().Eliminar(cEUsuarios, out mensaje);

                    if (resultado)
                    {
                        dgvUsuarios.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
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
            txtApellido.Text = string.Empty;
            txtNombres.Text = string.Empty;
            nudNivel.Value = 10;
            cboFuncion.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            chbActivo.Checked = true;
            txtUserRegistro.Text = string.Empty;
            txtApellido.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvUsuarios_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvUsuarios_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvUsuarios.Rows[indice].Cells["id_Usuario"].Value.ToString();
                    txtApellido.Text = dgvUsuarios.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtNombres.Text = dgvUsuarios.Rows[indice].Cells["Nombres"].Value.ToString();
                    nudNivel.Value = Convert.ToInt32(dgvUsuarios.Rows[indice].Cells["Nivel"].Value.ToString());
                    cboFuncion.Text = dgvUsuarios.Rows[indice].Cells["Funcion"].Value.ToString();
                    txtUsuario.Text = dgvUsuarios.Rows[indice].Cells["Usuario"].Value.ToString();
                    txtClave.Text = dgvUsuarios.Rows[indice].Cells["Clave"].Value.ToString();
                    chbActivo.Checked = Convert.ToBoolean(dgvUsuarios.Rows[indice].Cells["Activo"].Value);
                    txtUserRegistro.Text = dgvUsuarios.Rows[indice].Cells["UserRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = cboBusqueda.SelectedItem.ToString();

            if (dgvUsuarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvUsuarios.Rows)
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
            foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
