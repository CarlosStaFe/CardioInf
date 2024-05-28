using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlHistoriasOld : Form
    {
        CN_Historias cN_Historias = new CN_Historias();

        string NombreBoton, texto, respuesta;
        int documento, idpac;
        string apellido;


        public mdlHistoriasOld(string nombreboton, string id, string apel, string doc)
        {
            InitializeComponent();
            NombreBoton = nombreboton;
            idpac = Convert.ToInt32(id);
            apellido = apel;
            documento = Convert.ToInt32(doc);
        }

        private void mdlHistoriasOld_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargarDGV();

            txtFiltro.Select();
        }

        private void CargarDGV()
        {
            List<CE_HistoriasOld> ListaHis = new CN_HistoriasOld().ListaHistorias();

            //***** CARGO EL DGV *****
            foreach (CE_HistoriasOld item in ListaHis)
            {
                dgvHistorias.Rows.Add(new object[] { "", item.id_His, item.idPaciente, item.Documento, item.ApelNombres, item.Medico, item.Fecha, item.Comentario, item.Adjunto,
                                                    item.UserRegistro, item.FechaRegistro });
            }
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvHistorias.Rows.Clear();

            texto = txtFiltro.Text;

            CargarDGV();
        }

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            texto = txtFiltro.Text;
            dgvHistorias.Rows.Clear();
            CargarDGV();
        }

        //***** PROCEDIMIENTO PARA MARCAR LAS HISTORIAS ELEGIDAS *****
        private void dgvHistorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistorias.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                int indice = e.RowIndex;

                if (Convert.ToString(dgvHistorias.Rows[indice].Cells["Seleccion"].Value) == "")
                {
                    if (indice >= 0)
                    {
                        dgvHistorias.Rows[indice].Cells["Seleccion"].Value = "X";
                        dgvHistorias.Rows[indice].Cells["Seleccion"].Style.ForeColor = Color.Red;
                        dgvHistorias.Rows[indice].Cells["Seleccion"].Style.BackColor = Color.Yellow;
                    }
                }
                else
                {
                    if (indice >= 0)
                    {
                        dgvHistorias.Rows[indice].Cells["Seleccion"].Value = "";
                        dgvHistorias.Rows[indice].Cells["Seleccion"].Style.ForeColor = Color.White;
                        dgvHistorias.Rows[indice].Cells["Seleccion"].Style.BackColor = Color.Black;
                    }
                }
            }
        }

        //***** PROCEDIMIENTO PARA GRABAR LAS HISTORIAS VIAJAS A LAS NUEVAS *****
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            foreach (DataGridViewRow row in dgvHistorias.Rows)
            {
                if (Convert.ToString(row.Cells["Seleccion"].Value) == "X")
                {
                    CE_Historias cE_Historias = new CE_Historias()
                    {
                        idPcte = Convert.ToInt32(idpac),
                        NroDoc = Convert.ToInt32(documento),
                        NombreCompleto = apellido,
                        Medico = row.Cells["Medico"].Value.ToString(),
                        Fecha = Convert.ToDateTime(row.Cells["Fecha"].Value.ToString()),
                        Comentario = row.Cells["Comentario"].Value.ToString(),
                        Obs = row.Cells["Adjunto"].Value.ToString(),
                        UserRegistro = CE_UserLogin.Usuario,
                        FechaRegistro = DateTime.Today
                    };

                    int idHisto = new CN_Historias().Registrar(cE_Historias, out mensaje);

                    txtId.Text = row.Cells["id_Historia"].Value.ToString();

                    CE_HistoriasOld cEHistoriasOld = new CE_HistoriasOld()
                    {
                        id_His = Convert.ToInt32(txtId.Text),
                    };

                    bool resultado = new CN_HistoriasOld().Eliminar(cEHistoriasOld, out mensaje);

                }
            }

            Close();


        }
    }
}
