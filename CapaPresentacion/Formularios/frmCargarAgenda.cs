using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion.Formularios
{
    public partial class frmCargarAgenda : Form
    {
        private string respuesta;

        public frmCargarAgenda()
        {
            InitializeComponent();
        }

        private void frmCargarAgenda_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            CargarCombos();

            List<CE_PlanesOS> ListaPlanes = new CN_PlanesOS().ListaPlanes();

            //***** CARGO EL DGV *****
            foreach (CE_PlanesOS item in ListaPlanes)
            {
                dgvAgendas.Rows.Add(new object[] { "", item.id_Plan, item.OSPlan, item.NombrePlan, item.Estado, item.FecEstado, item.Obs, item.UserRegistro, item.FechaRegistro });
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

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvAgendas.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvAgendas.Rows[i].Cells["FecEstado"].Value);
            }
        }

        //***** SI EL ID DEL VALOR = 0 REGISTRA, SINO EDITA *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE TURNO...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                CE_Agendas cE_Agendas = new CE_Agendas()
                {
                    id_Agda = Convert.ToInt32(txtId.Text),
                    Fecha = DateTime.Now,
                    Profesional = cboProfesionales.Text,
                    Turno = Convert.ToInt32(cboTurno.Text),
                    Tipo = cboTipoConsulta.Text,
                    Pacte = Convert.ToInt32(txtPaciente.Text),
                    NumeroEco = 0,
                    Estado = cboEstado.Text,
                    FecEstado = DateTime.Now,
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
                        dgvAgendas.Rows.Add(new object[] { "", idAgda, DateTime.Now, cboProfesionales.Text, cboTurno.Text, cboTipoConsulta.Text, txtPaciente.Text, 0,
                                                            cboEstado.Text, DateTime.Now,txtObs.Text, txtUserRegistro.Text, txtFechaRegistro.Text });
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
                        DataGridViewRow row = dgvAgendas.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Plan"].Value = txtId.Text;
                        row.Cells["OSPLan"].Value = cboObraSocial.Text;
                        row.Cells["NombrePlan"].Value = txtPlan.Text;
                        row.Cells["Estado"].Value = cboTurno.Text;
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

        //***** CARGO EL COMBO DE LAS OBRAS SOCIALES *****
        private void CargarCombos()
        {
            cboObraSocial.Items.Clear();
            cboObraSocial.Text = string.Empty;

            List<CE_ObrasSociales> ListaOS = new CN_ObrasSociales().ListaOS();

            foreach (CE_ObrasSociales item in ListaOS)
            {
                cboObraSocial.Items.Add(item.Nombre);
                cboObraSocial.SelectedIndex = -1;
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
            cboObraSocial.Text = String.Empty;
            txtPlan.Text = String.Empty;
            cboEstado.Text = String.Empty;
            txtObs.Text = String.Empty;

            cboObraSocial.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****

    }
}
