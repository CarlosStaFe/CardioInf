using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmArrobas : Form
    {
        CN_Arrobas cN_Arrobas = new CN_Arrobas();
        private string respuesta;

        public frmArrobas()
        {
            InitializeComponent();
        }

        private void frmArrobas_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Arrobas> ListaArrobas = new CN_Arrobas().ListaArrobas();

            //***** CARGO EL DGV *****
            foreach (CE_Arrobas item in ListaArrobas)
            {
                dgvArrobas.Rows.Add(new object[] { "", item.id_Arroba, item.Detalle });
            }

            txtDetalle.Select();

        }

        //***** PROCEDIMIENTO BOTON GUARDAR/EDITAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTA ARROBA...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Arrobas cEArrobas = new CE_Arrobas()
                {
                    id_Arroba = Convert.ToInt32(txtId.Text),
                    Detalle = txtDetalle.Text
                };

                //***** SI EL ID DEL BOTÓN = 0 REGISTRA, SINO EDITA *****
                if (cEArrobas.id_Arroba == 0)
                {
                    int idArroba = new CN_Arrobas().Registrar(cEArrobas, out mensaje);

                    if (idArroba != 0)
                    {
                        dgvArrobas.Rows.Add(new object[] { "", idArroba, txtDetalle.Text });
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
                    bool resultado = new CN_Arrobas().Editar(cEArrobas, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvArrobas.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Arroba"].Value = txtIndice.Text;
                        row.Cells["Detalle"].Value = txtDetalle.Text;

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
            txtId.Text = "0";
            txtDetalle.Text = string.Empty;
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvArrobas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvArrobas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArrobas.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvArrobas.Rows[indice].Cells["id_Arroba"].Value.ToString();
                    txtDetalle.Text = dgvArrobas.Rows[indice].Cells["Detalle"].Value.ToString();
                }
            }
        }
    }
}
