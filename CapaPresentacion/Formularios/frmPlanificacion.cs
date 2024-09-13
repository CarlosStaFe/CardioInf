using System;
using System.Globalization;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPlanificacion : Form
    {
        int contador;
        int mes, anio;
        string nombre;
        public static int static_mes, static_anio;

        public frmPlanificacion()
        {
            InitializeComponent();
        }

        private void frmPlanificacion_Load(object sender, EventArgs e)
        {
            MostrarDias();
        }

        private void MostrarDias()
        {
            DateTime now = DateTime.Now;
            mes = now.Month;
            anio = now.Year;
            static_mes = mes;
            static_anio = anio;

            ArmarCalendario();
        }

        //***** BOTÓN SALIR DE LA PANTALLA *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ArmarCalendario()
        {
            contador = 0;

            nombre = DateTimeFormatInfo.CurrentInfo.GetMonthName(mes);

            lblNombre.Text = nombre.ToUpper() + " " + anio;

            //Traemos el primer día del mes.
            DateTime primerDiaMes = new DateTime(anio, mes, 1);

            //Traemos la cantidad de días.
            int dias = DateTime.DaysInMonth(anio, mes);

            //Convertimos los dias a enteros.
            int diaSemana = Convert.ToInt32(primerDiaMes.DayOfWeek.ToString("d")) + 1;

            for (int i = 1; i < diaSemana; i++)
            {
                ControlBlanco ctrlblank = new ControlBlanco();
                fpnlContenedor.Controls.Add(ctrlblank);
                contador++;
            }

            for (int i = 1; i <= dias; i++)
            {
                ControlDia ctrldias = new ControlDia();
                ctrldias.Dias(i);
                fpnlContenedor.Controls.Add(ctrldias);
                contador++;
            }

            for (int i = contador; i < 42; i++)
            {
                ControlBlanco ctrlblank = new ControlBlanco();
                fpnlContenedor.Controls.Add(ctrlblank);
            }
        }

        //Muestro el mes anterior.
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            fpnlContenedor.Controls.Clear();

            mes--;

            if (mes < 1)
            {
                mes = 12;
                anio--;
            }

            static_mes = mes;
            static_anio = anio;

            ArmarCalendario();
        }

        //Muestro el mes siguiente
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            fpnlContenedor.Controls.Clear();

            mes++;

            if (mes > 12)
            {
                mes = 1;
                anio++;
            }

            static_mes = mes;
            static_anio = anio;

            ArmarCalendario();
        }
    }
}
