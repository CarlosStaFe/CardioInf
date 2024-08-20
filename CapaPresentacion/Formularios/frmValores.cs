using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class frmValores : Form
    {
        private string respuesta;

        public frmValores()
        {
            InitializeComponent();
        }

        private void frmValores_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            List<CE_Valores> ListaValores = new CN_Valores().ListaValores();

            //***** CARGO EL DGV *****
            foreach (CE_Valores item in ListaValores)
            {
                dgvValores.Rows.Add(new object[] { "", item.id_Valor, item.Estudio, item.Valor, item.Estado, item.FechaEstado, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvValores.Columns)
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
            for (int i = 0; i < dgvValores.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvValores.Rows[i].Cells["FecEstado"].Value);
            }
        }

        //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE VALOR...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Valores cE_Valores = new CE_Valores()
                {
                    id_Valor = Convert.ToInt32(txtId.Text),
                    Estudio = cboEstudio.Text,
                    Valor = txtValor.Text,
                    Estado = cboEstado.Text,
                    FechaEstado = DateTime.Now,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
                if (cE_Valores.id_Valor == 0)
                {
                    int idValor = new CN_Valores().Registrar(cE_Valores, out mensaje);

                    if (idValor != 0)
                    {
                        dgvValores.Rows.Add(new object[] {"",idValor,cboEstudio.Text,txtValor.Text,cboEstado.Text, DateTime.Now, txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text});
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
                    bool resultado = new CN_Valores().Editar(cE_Valores, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvValores.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Valor"].Value = txtId.Text;
                        row.Cells["Estudio"].Value = cboEstudio.Text;
                        row.Cells["Valor"].Value = txtValor.Text;
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
            cboEstudio.Text = String.Empty;
            txtValor.Text = String.Empty;
            cboEstado.Text = String.Empty;
            txtObs.Text = String.Empty;

            cboEstudio.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvValores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvValores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvValores.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvValores.Rows[indice].Cells["id_Valor"].Value.ToString();
                    cboEstudio.Text = dgvValores.Rows[indice].Cells["Estudio"].Value.ToString();
                    txtValor.Text = dgvValores.Rows[indice].Cells["Valor"].Value.ToString();
                    cboEstado.Text = dgvValores.Rows[indice].Cells["Estado"].Value.ToString();
                    txtObs.Text = dgvValores.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvValores.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvValores.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvValores.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvValores.Rows)
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
            foreach (DataGridViewRow row in dgvValores.Rows)
            {
                row.Visible = true;
            }
        }
    }
}
