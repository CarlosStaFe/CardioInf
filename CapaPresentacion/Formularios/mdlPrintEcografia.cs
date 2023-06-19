using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class mdlPrintEcografia : Form
    {
        public mdlPrintEcografia()
        {
            InitializeComponent();
        }

        private void mdlPrintEcografia_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSetPrincipal.Ecografias' Puede moverla o quitarla según sea necesario.
            this.ecografiasTableAdapter.Fill(this.dataSetPrincipal.Ecografias);

            this.reportViewer1.RefreshReport();
        }
    }
}
