using CapaEntidad;
using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPasar : Form
    {
        public frmPasar()
        {
            InitializeComponent();
        }

        private void btnPasar_Click(object sender, EventArgs e)
        {
            string mensaje;
            string lugarDetalle = "E:\\DBCardioInf\\detalleeco.csv";

            System.IO.StreamReader archivo = new System.IO.StreamReader(lugarDetalle);

            string linea;

            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(';');

                label1.Text = fila[53];

                CE_DetalleEco cE_DetalleEco = new CE_DetalleEco()
                {
                    id_DetEco = Convert.ToInt32(fila[0]),
                    NumeroDet = Convert.ToInt32(fila[1]),
                    Diagnostico = fila[2],
                    E1 = fila[3],
                    E2 = fila[4],
                    E31 = fila[5],
                    E32 = fila[6],
                    E33 = fila[7],
                    E34 = fila[8],
                    E35 = fila[9],
                    E36 = fila[10],
                    E37 = fila[11],
                    E38 = Convert.ToDecimal(fila[12]),
                    E39 = Convert.ToDecimal(fila[13]),
                    E310 = fila[14],
                    E310p = Convert.ToDecimal(fila[15]),
                    E311 = fila[16],
                    E312 = fila[17],
                    E313 = fila[18],
                    E314 = fila[19],
                    E315 = fila[20],
                    E316 = fila[21],
                    E41 = fila[22],
                    E41v = Convert.ToDecimal(fila[23]),
                    E41g = Convert.ToDecimal(fila[24]),
                    E42 = fila[25],
                    E42v = Convert.ToDecimal(fila[26]),
                    E42g = Convert.ToDecimal(fila[27]),
                    E43 = fila[28],
                    E43v = Convert.ToDecimal(fila[29]),
                    E43g = Convert.ToDecimal(fila[30]),
                    E44 = fila[31],
                    E44v = Convert.ToDecimal(fila[32]),
                    E44g = Convert.ToDecimal(fila[33]),
                    E45 = fila[34],
                    E45v = Convert.ToDecimal(fila[35]),
                    E45g = Convert.ToDecimal(fila[36]),
                    E46 = fila[37],
                    E46v = Convert.ToDecimal(fila[38]),
                    E46g = Convert.ToDecimal(fila[39]),
                    E47 = fila[40],
                    E47v = Convert.ToDecimal(fila[41]),
                    E47g = Convert.ToDecimal(fila[42]),
                    E48 = fila[43],
                    E48v = Convert.ToDecimal(fila[44]),
                    E48g = Convert.ToDecimal(fila[45]),
                    E49 = fila[46],
                    E49v = Convert.ToDecimal(fila[47]),
                    E49g = Convert.ToDecimal(fila[48]),
                    E410 = fila[49],
                    E410v = Convert.ToDecimal(fila[50]),
                    E410g = Convert.ToDecimal(fila[51]),
                    E5 = fila[52],
                    E6 = fila[53],
                    UserRegistro = fila[54],
                    FechaRegistro = Convert.ToDateTime(fila[55])
                };

                int idDetEco = new CN_DetalleEco().Registrar(cE_DetalleEco, out mensaje);

                label1.Text = fila[1];
            }
        }
    }
}
