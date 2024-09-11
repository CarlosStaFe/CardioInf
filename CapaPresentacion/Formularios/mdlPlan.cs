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
        string fecha, idPlan, desde, hasta, senial;
        int desdeHr, desdeMin, hastaHr, hastaMin, rango, minutos, paso;

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
                if (nudMinutosDes.Value == 0) desde = "00";
                if (nudMinutosHas.Value == 0) hasta = "00";

                CE_Planificacion cEPlanificacion = new CE_Planificacion()
                {
                    id_Plan = Convert.ToInt32(idPlan),
                    Fecha = Convert.ToDateTime(fecha),
                    Medico = cboProfesionales.Text,
                    Tipo = cboTipoConsulta.Text,
                    DesdeHr = Convert.ToString(nudHoraDes.Value),
                    //DesdeMin = Convert.ToString(nudMinutosDes.Value),
                    DesdeMin = desde,
                    HastaHr = Convert.ToString(nudHoraHas.Value),
                    //HastaMin = Convert.ToString(nudMinutosHas.Value),
                    HastaMin = hasta,
                    Rango = Convert.ToString(nudRango.Value),
                    UserRegistro = txtUserRegistro.Text,
                    FechaRegistro = DateTime.Now
                };

                //***** SI EL ID DEL BOTÓN = 0 REGISTRA, SINO EDITA *****
                if (cEPlanificacion.id_Plan == 0)
                {
                    int idPlan = new CN_Planificacion().Registrar(cEPlanificacion, out mensaje);

                    if (idPlan != 0)
                    {
                        senial = "0";
                        ArmarAgenda();
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
                        senial = "1";
                        ArmarAgenda();
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
            nudRango.Value = 10;
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
                        EliminarAgda();
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
                nudRango.Value = Convert.ToInt32(item.Rango);
            }
        }

        //***** LEO EL PLAN SELECCIONADO PARA MOSTRARLO *****
        private void ArmarAgenda()
        {
            string mensaje = string.Empty;

            if (senial == "1")
            {
                EliminarAgda();
            }

            desdeHr = Convert.ToInt32(nudHoraDes.Value);
            desdeMin = Convert.ToInt32(nudMinutosDes.Value);
            hastaHr = Convert.ToInt32(nudHoraHas.Value);
            hastaMin = Convert.ToInt32(nudMinutosDes.Value);
            rango = Convert.ToInt32(nudRango.Value);
            minutos = 59;
            paso = 0;

            for (int i = desdeHr; i < hastaHr; i++)
            {
                for (int j = desdeMin; j < minutos; j = j + rango)
                {
                    CE_Agendas cE_Agendas = new CE_Agendas()
                    {
                        id_Agda = 0,
                        Fecha = Convert.ToDateTime(fecha),
                        Profesional = cboProfesionales.Text,
                        Hora = i,
                        Minutos = j,
                        Turno = 99,
                        Tipo = cboTipoConsulta.Text,
                        Pacte = 0,
                        Detalle = "",
                        NumeroEco = 0,
                        Estado = "LIBRE",
                        FechaEstado = DateTime.Now,
                        Obs = "",
                        UserRegistro = CE_UserLogin.Usuario,
                        FechaRegistro = DateTime.Today
                    };

                    int idAgda = new CN_Agendas().Registrar(cE_Agendas, out mensaje);
                }
            }
        }

        //***** ELIMINO LA PLANIFICACIÓN EN LA AGENDA *****
        private void EliminarAgda()
        {
            string mensaje = string.Empty;

            bool resultado = new CN_Agendas().BorrarAgda(fecha, cboProfesionales.Text);
        }


    }
}
