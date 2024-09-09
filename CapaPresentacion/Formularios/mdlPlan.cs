using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlPlan : Form
    {
        private string respuesta;
        string fecha, idPlan, desdeMin, hastaMin;

        public mdlPlan(string id)
        {
            idPlan = id;
            InitializeComponent();
        }

        private void mdlPlan_Load(object sender, EventArgs e)
        {
            txtDia.Text = ControlDia.static_dia + "/" + frmPlanificacion.static_mes + "/" + frmPlanificacion.static_anio;
            fecha = frmPlanificacion.static_anio + "-" + frmPlanificacion.static_mes + "-" + ControlDia.static_dia;
            CargarCombos();

            if (idPlan != "0")
            {
                LeerPlan();
            }
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

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON GUARDAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE PLAN...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                if (nudMinutosDes.Value == 0) desdeMin = "00";
                if (nudMinutosHas.Value == 0) hastaMin = "00";

                CE_Planificacion cEPlanificacion = new CE_Planificacion()
                {
                    id_Plan = Convert.ToInt32(idPlan),
                    Fecha = Convert.ToDateTime(fecha),
                    Medico = cboProfesionales.Text,
                    Tipo = cboTipoConsulta.Text,
                    DesdeHr = Convert.ToString(nudHoraDes.Value),
                    //DesdeMin = Convert.ToString(nudMinutosDes.Value),
                    DesdeMin = desdeMin,
                    HastaHr = Convert.ToString(nudHoraHas.Value),
                    //HastaMin = Convert.ToString(nudMinutosHas.Value),
                    HastaMin = hastaMin,
                    UserRegistro = txtUserRegistro.Text,
                    FechaRegistro = DateTime.Now
                };

                //***** SI EL ID DEL BOTÓN = 0 REGISTRA, SINO EDITA *****
                if (cEPlanificacion.id_Plan == 0)
                {
                    int idPlan = new CN_Planificacion().Registrar(cEPlanificacion, out mensaje);

                    if (idPlan != 0)
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
                    bool resultado = new CN_Planificacion().Editar(cEPlanificacion, out mensaje);

                    if (resultado)
                    {

                        Limpiar();
                    }
                    else
                    {
                        mensaje += "VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
                Close();
            }
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            cboProfesionales.Text = "";
            cboTipoConsulta.Text = "";
            nudHoraDes.Value = 8;
            nudMinutosDes.Value = 0;
            nudHoraHas.Value = 20;
            nudMinutosHas.Value = 0;
        }

        //***** PROCEDIMIENTO DEL BOTON ELIMINAR *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (Convert.ToInt32(idPlan) != 0)
            {
                mensaje += "DESEA ELIMINAR ESTA PLANIFICACION...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();

                if (respuesta == "OK")
                {
                    CE_Planificacion cEPlanificacion = new CE_Planificacion()
                    {
                        id_Plan = Convert.ToInt32(idPlan),
                    };

                    bool resultado = new CN_Planificacion().Eliminar(cEPlanificacion, out mensaje);

                    if (resultado)
                    {

                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
            }
            Close();
        }

        //***** LEO EL PLAN SELECCIONADO PARA MOSTRARLO *****
        private void LeerPlan()
        {
            List<CE_Planificacion> BuscaPlan = new CN_Planificacion().BuscarPlan(idPlan);

            foreach (CE_Planificacion item in BuscaPlan)
            {
                cboProfesionales.Text = item.Medico.ToString();
                cboTipoConsulta.Text = item.Tipo.ToString();
                nudHoraDes.Value = Convert.ToInt32(item.DesdeHr);
                nudMinutosDes.Value = Convert.ToInt32(item.DesdeMin);
                nudHoraHas.Value = Convert.ToInt32(item.HastaHr);
                nudMinutosHas.Value = Convert.ToInt32(item.HastaMin);
            }
        }
    }
}
