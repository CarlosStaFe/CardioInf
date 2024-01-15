using CapaPresentacion.Utiles;
using System;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlInformeEco : Form
    {
        string numeroeco;
        string buscar, nombrePDF, path, linea, senial;

        public mdlInformeEco(string nombre, string numero, string desde)
        {
            nombrePDF = nombre;
            numeroeco = numero;
            senial = desde;

            InitializeComponent();
        }

        private void mdlInformeEco_Load(object sender, EventArgs e)
        {
            if (senial == "1") btnEditar.Visible = false;
            if (senial == "2") btnEditar.Visible = true;

            spCabeceraTableAdapter.Fill(dataSetPrincipal.spCabecera, _Numero: numeroeco);
            spDetalleTableAdapter.Fill(dataSetPrincipal.spDetalle, _Numero: numeroeco);

            var deviceInfo = @"<DeviceInfo>
                                <EmbedFonts>None</EmbedFonts>
                                </DeviceInfo>";

            byte[] bytes = reportViewer1.LocalReport.Render("PDF", deviceInfo);

            buscar = "PathEcografias";
            linea = new LeerConfig().Proceso(buscar);
            path = linea + nombrePDF + ".pdf";

            var newFile = new FileStream(path, FileMode.Create);

            newFile.Write(bytes, 0, bytes.Length);
            newFile.Close();

            reportViewer1.RefreshReport();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string paciente = "";
            string tipo = "";
            string fecha = DateTime.Now.ToString();
            int id = 0;

            frmEcografia Eco = new frmEcografia(paciente, tipo, fecha, id, numeroeco, path);
            AddOwnedForm(Eco);
            Eco.ShowDialog();
            Close();
        }

    }
}
