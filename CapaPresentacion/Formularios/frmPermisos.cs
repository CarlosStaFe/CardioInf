using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPermisos : Form
    {
        private string respuesta;

        public frmPermisos()
        {
            InitializeComponent();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargoCboBotones();
            CargoCboUsuarios();
            Limpiar();
        }

        //***** CARGO EL COMBO DE BOTONES *****
        private void CargoCboBotones()
        {
            List<CE_Botones> ListaBoton = new CN_Botones().ListaBoton();

            cboBotones.Items.Clear();
            cboBotones.DataSource = ListaBoton;
            cboBotones.DisplayMember = "Detalle";
            cboBotones.ValueMember = "id_Boton";
        }

        //***** CARGO EL COMBO DE USUARIOS *****
        private void CargoCboUsuarios()
        {
            List<CE_Usuarios> ListaUser = new CN_Usuarios().ListaUser();

            cboUsuarios.Items.Clear();
            cboUsuarios.DataSource = ListaUser;
            cboUsuarios.DisplayMember = "Usuario";
            cboUsuarios.ValueMember = "id_Usuario";
        }

        //***** CARGO EL DGV SEGÚN LA SELECCIÓN DEL COMBO DE USUARIOS *****
        private void cboUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(cboUsuarios.SelectedValue);

            dgvPermisos.Rows.Clear();

            List<CE_Permisos> ListaPermisos = new CN_Permisos().ListaPermisos(idUsuario);

            //***** CARGO EL DGV *****
            foreach (CE_Permisos item in ListaPermisos)
            {
                dgvPermisos.Rows.Add(new object[] { "", item.id_Permiso, item.fk_Usuarios, item.fk_Botones, item.Nombre, item.Detalle, item.UserRegistro });
            }
        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string Mensaje = string.Empty;

            Mensaje += "DESEA REGISTRAR ESTE PERMISO...???";
            frmMsgBox msg = new frmMsgBox(Mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_PermisosNew cE_PermisosNew = new CE_PermisosNew()
                {
                    id_Permiso = Convert.ToInt32(txtId.Text),
                    fk_Usuarios = Convert.ToInt32(cboUsuarios.SelectedValue),
                    fk_Botones = Convert.ToInt32(cboBotones.SelectedValue),
                    UserRegistro = CE_UserLogin.Usuario
                };

                //*****SI EL ID DEL PERMISO = 0 REGISTRA, SINO EDITA *****
                if (cE_PermisosNew.id_Permiso == 0)
                {
                    int idPermiso = new CN_PermisosNew().Registrar(cE_PermisosNew, out Mensaje);
                    if (idPermiso != 0)
                    {
                        dgvPermisos.Rows.Add(new object[] { "", idPermiso, Convert.ToInt32(cboUsuarios.SelectedValue), Convert.ToInt32(cboBotones.SelectedValue), txtUserRegistro.Text });
                        Limpiar();
                    }
                    else
                    {
                        Mensaje += ". VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(Mensaje, "info", 1);
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
                mensaje += "DESEA ELIMINAR ESTE PERMISO...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();

                if (respuesta == "OK")
                {
                    CE_PermisosNew cEPermisosNew = new CE_PermisosNew()
                    {
                        id_Permiso = Convert.ToInt32(txtId.Text),
                    };

                    bool resultado = new CN_PermisosNew().Eliminar(cEPermisosNew, out mensaje);

                    if (resultado)
                    {
                        dgvPermisos.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
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
            dgvPermisos.Rows.Clear();

            txtId.Text = "0";
            cboUsuarios.Text = string.Empty;
            cboBotones.Text = string.Empty;
            txtUserRegistro.Text = string.Empty;
            cboUsuarios.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvPermisos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvPermisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPermisos.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvPermisos.Rows[indice].Cells["id_Permiso"].Value.ToString();
                    cboBotones.Text = dgvPermisos.Rows[indice].Cells["Detalle"].Value.ToString();
                }
            }
        }
    }
}
