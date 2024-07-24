using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmVerAgenda : Form
    {
        private string estadolist;
        string tipo, fecha, numeroeco, path, fechaagenda, estadonew;
        int id, nivel;

        public frmVerAgenda()
        {
            InitializeComponent();
        }

        private void frmVerAgenda_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            nivel = CE_UserLogin.Nivel;
            fechaagenda = dtpFecha.Text;
            fechaagenda = new ProcesarFecha().Procesar(fechaagenda);

            AgendaParticular();
        }

        //***** CARGO LA AGENDA DEL PROFESIONAL INGRESADO *****
        private void AgendaParticular()
        {
            dgvAgendas.Rows.Clear();

            //***** CARGO EL DGV SEGÚN EL USUARIO *****

            if (txtUserRegistro.Text == "DUREC" || txtUserRegistro.Text == "ADMIN")
            {
                List<CE_Agendas> AgdaCorta = new CN_Agendas().ListaAgendas(fechaagenda);

                foreach (CE_Agendas item in AgdaCorta)
                {
                    dgvAgendas.Rows.Add(new object[] { "", item.id_Agda, item.Fecha, item.Hora, item.Minutos, item.Turno, item.Detalle, item.Tipo, item.Pacte, item.NumeroEco, item.Estado, item.FechaEstado, item.Obs, item.Profesional,
                                                    item.UserRegistro, item.FechaRegistro });
                }
            }
            else
            {
                List<CE_Agendas> AgdaCorta = new CN_Agendas().AgendaCorta(txtUserRegistro.Text, fechaagenda);

                foreach (CE_Agendas item in AgdaCorta)
                {
                    dgvAgendas.Rows.Add(new object[] { "", item.id_Agda, item.Fecha, item.Hora, item.Minutos, item.Turno, item.Detalle, item.Tipo, item.Pacte, item.NumeroEco, item.Estado, item.FechaEstado, item.Obs, item.Profesional,
                                                    item.UserRegistro, item.FechaRegistro });
                }
            }

            Colorear();
        }

        //***** CARGO LA PANTALLA DE HISTORIAS CLÍNICAS *****
        private void btnHC_Click(object sender, EventArgs e)
        {
            frmHistorias Hist = new frmHistorias(Convert.ToInt32(txtPaciente.Text));
            AddOwnedForm(Hist);
            Hist.ShowDialog();

            lblNombre.Visible = false;
            lblEstado.Visible = false;
            cboEstado.Visible = false;
            lblHC.Visible = false;
            btnHC.Visible = false;
            btnAgregar.Visible = false;
        }

        //***** GRABO EL ESTADO MODIFICADO *****
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            estadonew = cboEstado.Text;
            var ok = new CN_Agendas().ActualizoEstado(id, estadonew);
            AgendaParticular();
        }

        //***** CAMBIO LA FECHA DE LA BÚSQUEDA *****
        private void dtpFecha_CloseUp(object sender, EventArgs e)
        {
            fechaagenda = dtpFecha.Text;
            fechaagenda = new ProcesarFecha().Procesar(fechaagenda);

            AgendaParticular();
        }

        //***** COLOREO LA CELDA SI LA FECHA ES MENOR *****
        private void Colorear()
        {
            for (int i = 0; i < dgvAgendas.Rows.Count; i++)
            {
                estadolist = Convert.ToString(dgvAgendas.Rows[i].Cells["Estado"].Value);

                if (estadolist == "EN ESPERA")
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Aquamarine;
                }
                if (estadolist == "COMPLETA" || estadolist == "ATENDIDO")
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Green;
                }
                if (estadolist == "CONSULTORIO")
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.White;
                }
                if (estadolist == "CANCELADO")
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Red;
                }
                if (estadolist == "ENVIADO")
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Blue;
                }
            }
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvAgendas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvAgendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgendas.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    lblNombre.Text = dgvAgendas.Rows[indice].Cells["ApellidoyNombres"].Value.ToString().Substring(0,30);
                    txtPaciente.Text = dgvAgendas.Rows[indice].Cells["Pacte"].Value.ToString();
                    tipo = dgvAgendas.Rows[indice].Cells["TipoEst"].Value.ToString();
                    fecha = dgvAgendas.Rows[indice].Cells["FecTurno"].Value.ToString();
                    id = Convert.ToInt32(dgvAgendas.Rows[indice].Cells["id_Plan"].Value.ToString());
                    numeroeco = dgvAgendas.Rows[indice].Cells["numero"].Value.ToString();
                    path = "";

                    if (tipo.Trim() == "Ecocardiograma Doppler Color Pediátrico" || tipo == "Ecocardiograma Doppler Color Fetal")
                    {
                        lblNombre.Visible = false;
                        lblEstado.Visible = false;
                        cboEstado.Visible = false;
                        lblHC.Visible = false;
                        btnHC.Visible = false;
                        btnAgregar.Visible = false;

                        frmEcografia Eco = new frmEcografia(txtPaciente.Text, tipo, fecha, id, numeroeco, path);
                        AddOwnedForm(Eco);
                        Eco.ShowDialog();
                    }
                    else
                    {
                        lblNombre.Visible = true;
                        lblEstado.Visible = true;
                        cboEstado.Visible = true;
                        lblHC.Visible = true;
                        btnHC.Visible = true;
                        btnAgregar.Visible = true;
                    }
                }

                AgendaParticular();
            }
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
