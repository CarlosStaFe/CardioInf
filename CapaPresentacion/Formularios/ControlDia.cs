using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class ControlDia : UserControl
    {
        public static string static_dia;
        string dia;
        int cont;
        string id1, id2, id3;

        public ControlDia()
        {
            InitializeComponent();
        }

        private void ControlDia_Load(object sender, EventArgs e)
        {

        }

        public void Dias(int nrodia)
        {
            lblDia.Text = nrodia + "";
            dia = Convert.ToString(nrodia);
            MostrarEvento();
        }

        private void ControlDia_Click(object sender, EventArgs e)
        {

        }

        private void MostrarEvento()
        {
            cont = 0;

            Limpiar();

            List<CE_Planificacion> ListaPlan = new CN_Planificacion().ListaPlan(frmPlanificacion.static_anio + "-" + frmPlanificacion.static_mes + "-" + dia);

            //***** CARGO EL DGV *****
            foreach (CE_Planificacion item in ListaPlan)
            {
                cont = cont + 1;
                if (cont == 1)
                {
                    id1 = item.id_Plan.ToString();
                    lblDoctor1.Text = item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Medico;
                    lblDetalle1.Text = item.Tipo;
                    lblDoctor1.Visible = true;
                    lblDetalle1.Visible = true;
                    btn1.Visible = true;
                }

                if (cont == 2)
                {
                    id2 = item.id_Plan.ToString();
                    lblDoctor2.Text = item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Medico;
                    lblDetalle2.Text = item.Tipo;
                    lblDoctor2.Visible = true;
                    lblDetalle2.Visible = true;
                    btn2.Visible = true;
                }

                if (cont == 3)
                {
                    id3 = item.id_Plan.ToString();
                    lblDoctor3.Text = item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Medico;
                    lblDetalle3.Text = item.Tipo;
                    lblDoctor3.Visible = true;
                    lblDetalle3.Visible = true;
                    btn3.Visible = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MostrarEvento();
        }

        private void lblDia_Click(object sender, EventArgs e)
        {
            static_dia = lblDia.Text;
            timer1.Start();
            mdlPlan plan = new mdlPlan("0");
            plan.Show();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            static_dia = lblDia.Text;
            timer1.Start();
            mdlPlan plan = new mdlPlan(id1);
            plan.Show();
            MostrarEvento();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            static_dia = lblDia.Text;
            timer1.Start();
            mdlPlan plan = new mdlPlan(id2);
            plan.Show();
            MostrarEvento();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            static_dia = lblDia.Text;
            timer1.Start();
            mdlPlan plan = new mdlPlan(id3);
            plan.Show();
            MostrarEvento();
        }

        private void Limpiar()
        {
            id1 = "";
            lblDoctor1.Text = "";
            lblDetalle1.Text = "";
            lblDoctor1.Visible = false;
            lblDetalle1.Visible = false;
            btn1.Visible = false;
            id2 = "";
            lblDoctor2.Text = "";
            lblDetalle2.Text = "";
            lblDoctor2.Visible = false;
            lblDetalle2.Visible = false;
            btn2.Visible = false;
            id3 = "";
            lblDoctor3.Text = "";
            lblDetalle3.Text = "";
            lblDoctor3.Visible = false;
            lblDetalle3.Visible = false;
            btn3.Visible = false;
        }
    }
}
