using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlPacientes : Form
    {
        CN_Pacientes cN_Pacientes = new CN_Pacientes();

        string NombreBoton;
        string texto = "";

        public mdlPacientes(string NombreBoton)
        {
            InitializeComponent();
            this.NombreBoton = NombreBoton;
        }

        private void mdlPacientes_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargarDGV();

            txtFiltro.Select();
        }

        private void CargarDGV()
        {
            List<CE_Pacientes> ListaPac = new CN_Pacientes().ListaPacte(texto);

            //***** CARGO EL DGV *****
            foreach (CE_Pacientes item in ListaPac)
            {
                dgvPacientes.Rows.Add(new object[] { "", item.id_Pacte, item.ApelNombres, item.FechaNacim, item.Sexo, item.TipoDoc, item.NumeroDoc, item.Domicilio, item.CodPostal,
                                                item.Telefono, item.Email, item.ObraSocial, item.PlanOS, item.Obs, item.UserRegistro, item.FechaRegistro, item.Afiliado });
            }

        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvPacientes_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvPacientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvPacientes.Rows[indice].Cells["id_Pacte"].Value.ToString();
                    txtApelNombres.Text = dgvPacientes.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                    txtFecNacim.Text = Convert.ToString(dgvPacientes.Rows[indice].Cells["FechaNacim"].Value.ToString());
                    txtSexo.Text = dgvPacientes.Rows[indice].Cells["Sexo"].Value.ToString();
                    txtTipoDoc.Text = dgvPacientes.Rows[indice].Cells["Tipo"].Value.ToString();
                    txtNumeroDoc.Text = dgvPacientes.Rows[indice].Cells["Numero"].Value.ToString();

                    int pos1 = txtFecNacim.Text.IndexOf(" ");
                    txtFecNacim.Text = txtFecNacim.Text.Substring(0, pos1);

                    if (NombreBoton == "btnCargarAgenda")
                    {
                        frmCargarAgenda AgdaPaciente = Owner as frmCargarAgenda;
                        AgdaPaciente.lblPaciente.Text = txtApelNombres.Text + " - " + txtFecNacim.Text + " - " + txtSexo.Text + " - " + txtTipoDoc.Text + ": " + txtNumeroDoc.Text;
                        AgdaPaciente.txtPaciente.Text = txtId.Text;
                        AgdaPaciente.txtFecNacim.Text = txtFecNacim.Text;
                        AgdaPaciente.txtSexo.Text = txtSexo.Text;
                        AgdaPaciente.txtTipoDoc.Text = txtTipoDoc.Text;
                        AgdaPaciente.txtNumeroDoc.Text = txtNumeroDoc.Text;
                        AgdaPaciente.txtApelNombres.Text = txtApelNombres.Text;
                        Close();
                        Dispose();
                    }
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPacientes.Rows.Clear();

            texto = txtFiltro.Text;

            CargarDGV();
        }

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            texto = txtFiltro.Text;
            dgvPacientes.Rows.Clear();
            CargarDGV();
        }
    }
}
