using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using CapaPresentacion.Utiles;

namespace CapaPresentacion.Formularios
{
    public partial class ControlDia : UserControl
    {
        public static string static_dia;
        string dia, fecha;
        int cont, senial;
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
                fecha = new ProcesarFecha().Procesar(Convert.ToString(item.Fecha));
                
                cont = cont + 1;

                if (item.Medico == "PASTOREC") senial = 1;
                if (item.Medico == "CONSTANZA") senial = 2;
                if (item.Medico == "ENZOP") senial = 3;

                if (cont == 1)
                {
                    id1 = item.id_Plan.ToString();
                    lblDoctor1.Text = item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Medico;
                    lblDetalle1.Text = item.Tipo;
                    lblDoctor1.Visible = true;
                    lblDetalle1.Visible = true;
                    btn1.Visible = true;
                    if (senial == 1)
                    {
                        lblDoctor1.BackColor = Color.DodgerBlue;
                        btn1.ForeColor = Color.Teal;
                        btn1.IconColor = Color.Teal;
                        txtDoctor1.Text = "PASTOREC";
                    }
                    if (senial == 2)
                    {
                        lblDoctor1.BackColor = Color.Green;
                        btn1.ForeColor = Color.Green;
                        btn1.IconColor = Color.Green;
                        txtDoctor1.Text = "CONSTANZA";
                    }
                    if (senial == 3)
                    {
                        lblDoctor1.BackColor = Color.Orchid;
                        btn1.ForeColor = Color.Orchid;
                        btn1.IconColor = Color.Orchid;
                        txtDoctor1.Text = "ENZOP";
                    }
                }

                if (cont == 2)
                {
                    id2 = item.id_Plan.ToString();
                    lblDoctor2.Text = item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Medico;
                    lblDetalle2.Text = item.Tipo;
                    lblDoctor2.Visible = true;
                    lblDetalle2.Visible = true;
                    btn2.Visible = true;
                    if (senial == 1)
                    {
                        lblDoctor2.BackColor = Color.DodgerBlue;
                        btn2.ForeColor = Color.Teal;
                        btn2.IconColor = Color.Teal;
                        txtDoctor2.Text = "PASTOREC";
                    }
                    if (senial == 2)
                    {
                        lblDoctor2.BackColor = Color.Green;
                        btn2.ForeColor = Color.Green;
                        btn2.IconColor = Color.Green;
                        txtDoctor2.Text = "CONSTANZA";
                    }
                    if (senial == 3)
                    {
                        lblDoctor2.BackColor = Color.Orchid;
                        btn2.ForeColor = Color.Orchid;
                        btn2.IconColor = Color.Orchid;
                        txtDoctor2.Text = "ENZOP";
                    }
                }

                if (cont == 3)
                {
                    id3 = item.id_Plan.ToString();
                    lblDoctor3.Text = item.DesdeHr + ":" + item.DesdeMin + " / " + item.HastaHr + ":" + item.HastaMin + " - " + item.Medico;
                    lblDetalle3.Text = item.Tipo;
                    lblDoctor3.Visible = true;
                    lblDetalle3.Visible = true;
                    btn3.Visible = true;
                    if (senial == 1)
                    {
                        lblDoctor3.BackColor = Color.DodgerBlue;
                        btn3.ForeColor = Color.Teal;
                        btn3.IconColor = Color.Teal;
                        txtDoctor3.Text = "PASTOREC";
                    }
                    if (senial == 2)
                    {
                        lblDoctor3.BackColor = Color.Green;
                        btn3.ForeColor = Color.Green;
                        btn3.IconColor = Color.Green;
                        txtDoctor3.Text = "CONSTANZA";
                    }
                    if (senial == 3)
                    {
                        lblDoctor3.BackColor = Color.Orchid;
                        btn3.ForeColor = Color.Orchid;
                        btn3.IconColor = Color.Orchid;
                        txtDoctor3.Text = "ENZOP";
                    }
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

        private void lblDoctor1_Click(object sender, EventArgs e)
        {
            frmCargarAgenda agenda = new frmCargarAgenda(fecha,txtDoctor1.Text);
            agenda.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            static_dia = lblDia.Text;
            timer1.Start();
            mdlPlan plan = new mdlPlan(id2);
            plan.Show();
            MostrarEvento();
        }

        private void lblDoctor2_Click(object sender, EventArgs e)
        {
            frmCargarAgenda agenda = new frmCargarAgenda(fecha,txtDoctor2.Text);
            agenda.Show();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            static_dia = lblDia.Text;
            timer1.Start();
            mdlPlan plan = new mdlPlan(id3);
            plan.Show();
            MostrarEvento();
        }

        private void lblDoctor3_Click(object sender, EventArgs e)
        {
            frmCargarAgenda agenda = new frmCargarAgenda(fecha,txtDoctor3.Text);
            agenda.Show();
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
