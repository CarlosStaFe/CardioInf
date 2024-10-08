﻿using System;
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
        private int orden;
        string fechaAgenda;
        int idpcte;
        int cont;
        string fechaHoy, medico;

        public frmCargarAgenda(string FechaHoy, string Medico)
        {
            InitializeComponent();
            fechaHoy = FechaHoy;
            medico = Medico;
        }

        private void frmCargarAgenda_Load(object sender, EventArgs e)
        {
            CargarCombos();

            fechaAgenda = fechaHoy;

            if (fechaAgenda != "")
            {
                dtpFecha.Text = fechaAgenda;
            }

            if (medico != "")
            {
                cboProfesionales.Text = medico;
                AgendaCorta();
            }
            else
            {
                AgendaCompleta();
            }

            txtUserRegistro.Text = CE_UserLogin.Usuario;
            fechaAgenda = new ProcesarFecha().Procesar(dtpFecha.Text);

            //CargarCombos();
            //AgendaCompleta();
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
            List<CE_Agendas> ListaAgda = new CN_Agendas().ListaAgendas(fechaAgenda);

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

            MostrarPlan();
        }

        //***** COLOREO LA CELDA SI LA FECHA ES MENOR *****
        private void Colorear()
        {
            for (int i = 0; i < dgvAgendas.Rows.Count; i++)
            {
                estadolist = Convert.ToString(dgvAgendas.Rows[i].Cells["Estado"].Value);
                orden = Convert.ToInt32(dgvAgendas.Rows[i].Cells["Turno"].Value);

                if (estadolist == "EN ESPERA" & orden < 99)
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Aquamarine;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.BackColor = Color.Aquamarine;

                }
                if ((estadolist == "COMPLETA" || estadolist == "ATENDIDO") & orden < 99)
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Green;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.BackColor = Color.Green;
                }
                if (estadolist == "CONSULTORIO" & orden < 99)
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.White;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.BackColor = Color.White;

                }
                if (estadolist == "CANCELADO" & orden < 99)
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Red;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.BackColor = Color.Red;
                }
                if (estadolist == "ENVIADO" & orden < 99)
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Blue;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Turno"].Style.BackColor = Color.Blue;
                }
                if (estadolist == "LIBRE" & orden == 99)
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.LimeGreen;
                    dgvAgendas.Rows[i].Cells["Hora"].Style.ForeColor = Color.Lime;
                    dgvAgendas.Rows[i].Cells["Minutos"].Style.ForeColor = Color.Lime;
                }
                if (estadolist == "OCUPADO")
                {
                    dgvAgendas.Rows[i].Cells["Estado"].Style.ForeColor = Color.LimeGreen;
                    dgvAgendas.Rows[i].Cells["Estado"].Style.BackColor = Color.Black;
                    dgvAgendas.Rows[i].Cells["Hora"].Style.ForeColor = Color.White;
                    dgvAgendas.Rows[i].Cells["Minutos"].Style.ForeColor = Color.White;
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
                    Fecha = Convert.ToDateTime(fechaAgenda),
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
            nudHora.Text = "8";
            nudMinutos.Text = "0";
            nudTurno.Text = "99";
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
            AgendaCorta();
            MostrarPlan();
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
            fechaAgenda = dtpFecha.Text;

            fechaAgenda = new ProcesarFecha().Procesar(fechaAgenda);

            AgendaCompleta();
        }

        //***** CARGO LA PANTALLA DE PACIENTES *****
        private void btnPaciente_Click(object sender, EventArgs e)
        {
            if (txtPaciente.Text == "") txtPaciente.Text = "0";

            idpcte = Convert.ToInt32(txtPaciente.Text);

            VarGlobales.pacienteId = idpcte;

            frmPacientes Pacte = new frmPacientes(idpcte);
            AddOwnedForm(Pacte);
            Pacte.ShowDialog();
            txtPaciente.Text = Convert.ToString(VarGlobales.pacienteId);

            LeerPaciente();

        }

        //***** CARGO LA PANTALLA DE PACIENTES *****
        private void MostrarPlan()
        {
            cont = 0;
            lblPlan1.Text = "";
            lblPlan2.Text = "";
            lblPlan3.Text = "";

            List<CE_Planificacion> Plan = new CN_Planificacion().LeePlan(fechaAgenda);

            foreach (CE_Planificacion item in Plan)
            {
                cont = cont + 1;
                if (cont == 1) lblPlan1.Text = item.Medico + " - " + item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Tipo;
                if (cont == 2) lblPlan2.Text = item.Medico + " - " + item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Tipo;
                if (cont == 3) lblPlan3.Text = item.Medico + " - " + item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Tipo;
            }
        }

        //***** CARGO LA AGENDA CORTA DE PROFESIONALES *****
        private void AgendaCorta()
        {
            dgvAgendas.Rows.Clear();
            fechaAgenda = new ProcesarFecha().Procesar(dtpFecha.Text);

            List<CE_Agendas> AgdaCorta = new CN_Agendas().AgendaCorta(cboProfesionales.Text, fechaAgenda);

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

        //***** PROCEDIMIENTO PARA LEER EL PACIENTE ENVIADO *****
        private void LeerPaciente()
        {
            List<CE_Pacientes> BuscaPacte = new CN_Pacientes().BuscarPacte(txtPaciente.Text);

            foreach (CE_Pacientes item in BuscaPacte)
            {
                txtPaciente.Text = Convert.ToString(item.id_Pacte);
                txtFecNacim.Text = Convert.ToString(item.FechaNacim);
                int pos1 = txtFecNacim.Text.IndexOf(" ");
                txtFecNacim.Text = txtFecNacim.Text.Substring(0, pos1);

                txtSexo.Text = item.Sexo;
                txtTipoDoc.Text = item.TipoDoc;
                txtNumeroDoc.Text = Convert.ToString(item.NumeroDoc);
                txtApelNombres.Text = item.ApelNombres;

                lblPaciente.Text = txtApelNombres.Text + " - " + txtFecNacim.Text + " - " + txtSexo.Text + " - " + txtTipoDoc.Text + ": " + txtNumeroDoc.Text;
            }
        }

    }
}
