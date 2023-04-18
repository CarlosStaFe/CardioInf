using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace CapaPresentacion.Formularios
{
    public partial class frmMsgBox : Form
    {
        public frmMsgBox()
        {
            InitializeComponent();
        }

        //***** PROCEDIMIENTO PARA VER LOS TIPO DE MENSAJES *****
        public frmMsgBox(string mensaje, string tipo, int boton)
        {
            InitializeComponent();

            lblMensaje.Text = mensaje;
            Tag = false;

            if (tipo == "info") //***** Logo amarillo
            {
                iconInformacion.Visible = true;
                iconCorrecto.Visible = false;
                iconAdvertencia.Visible = false;
                lblTitulo.Text = "ATENCIÓN Información...!!!";
                lblTitulo.ForeColor = Color.FromArgb(255, 255, 0);
            }

            if (tipo == "question") //***** Logo rojo
            {
                iconInformacion.Visible = false;
                iconCorrecto.Visible = false;
                iconAdvertencia.Visible = true;
                lblTitulo.Text = "ATENCIÓN...!!! Pregunta...";
                lblTitulo.ForeColor = Color.FromArgb(255, 0, 0);
            }

            if (tipo == "ok") //***** Logo verde
            {
                iconInformacion.Visible = false;
                iconCorrecto.Visible = true;
                iconAdvertencia.Visible = false;
                lblTitulo.Text = "Responder Opción...";
                lblTitulo.ForeColor = Color.FromArgb(0, 255, 0);
            }

            if (boton == 1)
            {
                btnAceptar.Visible = true;
                btnCancelar.Visible = false;
            }
            if (boton == 2)
            {
                btnAceptar.Visible = true;
                btnCancelar.Visible = true;
            }
        }

        //***** PROCEDIMIENTO PARA EL BOTON ACEPTAR *****
        private void btnAceptar_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        //***** PROCEDIMIENTO PARA EL BOTON CANCELAR *****
        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            Close();
        }
    }
}




