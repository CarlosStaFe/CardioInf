using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;

namespace CapaPresentacion.Formularios
{
    public partial class frmCargarAgenda : Form
    {
        private string respuesta;
        private string estadolist;
        string fechaagenda;

        public frmCargarAgenda()
        {
            InitializeComponent();
        }

        private void frmCargarAgenda_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            fechaagenda = new ProcesarFecha().Procesar(dtpFecha.Text);

            CargarCombos();
            AgendaCompleta();
        }

        //***** CARGO LA AGENDA DE TODOS LOS PROFESIONALES *****
        private void AgendaCompleta()
        {
            Limpiar();
            CargarAgenda();
        }

        //***** PROCEDIMIENTO PARA CARGAR LA AGENDA *****
        private void CargarAgenda()
        {
            List<CE_Agendas> ListaAgda = new CN_Agendas().ListaAgendas(fechaagenda);

            //***** CARGO EL DGV *****
            foreach (CE_Agendas item in ListaAgda)
            {
                dgvAgendas.Rows.Add(new object[] { "", item.id_Agda, item.Fecha, item.Hora, item.Minutos, item.Turno, item.Detalle, item.Tipo, item.Pacte, "", item.Estado, item.FechaEstado, item.Profesional, item.Obs,
                                                    item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvAgendas.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }
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

        //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (txtPaciente.Text == "")
            {
                MessageBox.Show("Debe ingresar un paciente...!!!");

                btnBuscaPacte.Select();
                return;
            }
            mensaje += "DESEA REGISTRAR ESTE TURNO...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Agendas cE_Agendas = new CE_Agendas()
                {
                    id_Agda = Convert.ToInt32(txtId.Text),
                    Fecha = Convert.ToDateTime(fechaagenda),
                    Profesional = cboProfesionales.Text,
                    Hora = Convert.ToInt32(nudHora.Text),
                    Minutos = Convert.ToInt32(nudMinutos.Text),
                    Turno = Convert.ToInt32(nudTurno.Text),
                    Tipo = cboTipoConsulta.Text,
                    Pacte = Convert.ToInt32(txtPaciente.Text),
                    Detalle = lblPaciente.Text,
                    NumeroEco = 0,
                    Estado = cboEstado.Text,
                    FechaEstado = DateTime.Now,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today
                };

                //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
                if (cE_Agendas.id_Agda == 0)
                {
                    int idAgda = new CN_Agendas().Registrar(cE_Agendas, out mensaje);

                    if (idAgda != 0)
                    {
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
                    bool resultado = new CN_Agendas().Editar(cE_Agendas, out mensaje);

                    if (resultado)
                    {
                        CargarAgenda();

                        //DataGridViewRow row = dgvAgendas.Rows[Convert.ToInt32(txtIndice.Text)];
                        //row.Cells["id_Agda"].Value = txtId.Text;
                        //row.Cells["Fecha"].Value = DateTime.Now;
                        //row.Cells["Profesional"].Value = cboProfesionales.Text;
                        //row.Cells["Turno"].Value = nudTurno.Text;
                        //row.Cells["Tipo"].Value = cboTipoConsulta.Text;
                        //row.Cells["Pacte"].Value = txtPaciente.Text;
                        //row.Cells["ApellidoyNombres"].Value = lblPaciente.Text;
                        //row.Cells["NumeroEco"].Value = 0;
                        //row.Cells["Estado"].Value = cboEstado.Text;
                        //row.Cells["Tipo"].Value = DateTime.Now;
                        //row.Cells["Obs"].Value = txtObs.Text;
                        //row.Cells["UserRegistro"].Value = txtUserRegistro.Text;
                        //row.Cells["FechaRegistro"].Value = txtFechaRegistro.Text;

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

            AgendaCompleta();
        }

        //***** CARGO EL COMBO DE LOS PROFESIONALES *****
        private void CargarCombos()
        {
            cboProfesionales.Items.Clear();
            cboProfesionales.Text = string.Empty;

            List<CE_Profesionales> ListaProf = new CN_Profesionales().ListaProf();

            foreach (CE_Profesionales item in ListaProf)
            {
                //cboProfesionales.Items.Add(item.ApelNombres);
                cboProfesionales.Items.Add(item.Usuario);
                cboProfesionales.SelectedIndex = -1;
            }
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
            AgendaCompleta() ;
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            dgvAgendas.Rows.Clear();
            txtId.Text = "0";
            txtIndice.Text = "0";
            txtPaciente.Text = string.Empty;
            lblPaciente.Text = string.Empty;
            cboProfesionales.Text = string.Empty; 
            cboTipoConsulta.Text = string.Empty;
            nudHora.Text = "0";
            nudMinutos.Text = "0";
            nudTurno.Text = "1";
            cboEstado.Text = String.Empty;
            txtObs.Text = String.Empty;

            btnBuscaPacte.Select();
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
            if (cboProfesionales.Text == String.Empty)
            {
                return;
            }
            else
            {
                if (dgvAgendas.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    int indice = e.RowIndex;

                    if (indice >= 0)
                    {
                        txtIndice.Text = indice.ToString();
                        txtId.Text = dgvAgendas.Rows[indice].Cells["id_Agda"].Value.ToString();
                        nudHora.Text = dgvAgendas.Rows[indice].Cells["Hora"].Value.ToString();
                        nudMinutos.Text = dgvAgendas.Rows[indice].Cells["Minutos"].Value.ToString();
                        cboProfesionales.Text = dgvAgendas.Rows[indice].Cells["Profesional"].Value.ToString();
                        nudTurno.Value = Convert.ToInt32(dgvAgendas.Rows[indice].Cells["Turno"].Value.ToString());
                        cboTipoConsulta.Text = dgvAgendas.Rows[indice].Cells["Tipo"].Value.ToString();
                        txtPaciente.Text = dgvAgendas.Rows[indice].Cells["Pacte"].Value.ToString();
                        lblPaciente.Text = dgvAgendas.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                        cboEstado.Text = dgvAgendas.Rows[indice].Cells["Estado"].Value.ToString();
                        txtObs.Text = dgvAgendas.Rows[indice].Cells["Obs"].Value.ToString();
                        txtUserRegistro.Text = dgvAgendas.Rows[indice].Cells["UserRegistro"].Value.ToString();
                        txtFechaRegistro.Text = dgvAgendas.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                    }
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = Regex.Replace(cboBusqueda.SelectedItem.ToString().Trim(), " ", String.Empty);

            if (dgvAgendas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvAgendas.Rows)
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
            foreach (DataGridViewRow row in dgvAgendas.Rows)
            {
                row.Visible = true;
            }
        }

        //***** PROCEDIMIENTO DEL BOTON DE BÚSQUEDA DE PACIENTE *****
        private void btnBuscaPacte_Click(object sender, EventArgs e)
        {
            mdlPacientes BuscaPacte = new mdlPacientes("btnCargarAgenda");
            AddOwnedForm(BuscaPacte);
            BuscaPacte.ShowDialog();
        }

        //***** CARGO LA AGENDA DEL PROFESIONAL SELECCIONADO *****
        private void cboProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAgendas.Rows.Clear();
            fechaagenda = new ProcesarFecha().Procesar(dtpFecha.Text);

            List<CE_Agendas> AgdaCorta = new CN_Agendas().AgendaCorta(cboProfesionales.Text,fechaagenda);

            //***** CARGO EL DGV *****
            foreach (CE_Agendas item in AgdaCorta)
            {
                dgvAgendas.Rows.Add(new object[] { "", item.id_Agda, item.Fecha, item.Hora, item.Minutos, item.Turno, item.Detalle, item.Tipo, item.Pacte, "", item.Estado, item.FechaEstado, item.Profesional, item.Obs,
                                                    item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvAgendas.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }

            btnEliminar.Visible = true;
        }

        //***** PROCESO PARA ELIMINAR PACIENTE DE LA AGENDA *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (Convert.ToInt32(txtId.Text) != 0)
            {
                mensaje += "DESEA ELIMINAR ESTE TURNO PARA EL PACIENTE...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();

                if (respuesta == "OK")
                {
                    CE_Agendas cEAgendas = new CE_Agendas()
                    {
                        id_Agda = Convert.ToInt32(txtId.Text),
                    };

                    bool resultado = new CN_Agendas().Eliminar(cEAgendas, out mensaje);

                    if (resultado)
                    {
                        dgvAgendas.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                Limpiar();
                AgendaCompleta();
            }
        }

        //***** CAMBIO LA FECHA DE BÚSQUEDA DE LA AGENDA *****
        private void dtpFecha_CloseUp(object sender, EventArgs e)
        {
            fechaagenda = dtpFecha.Text;

            fechaagenda = new ProcesarFecha().Procesar(fechaagenda);

            AgendaCompleta();
        }
    }
}
