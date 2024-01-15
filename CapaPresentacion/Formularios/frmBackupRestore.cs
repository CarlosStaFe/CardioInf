using CapaEntidad;
using CapaPresentacion.Utiles;
using System;
using System.IO;
using System.Windows.Forms;


namespace CapaPresentacion.Formularios
{
    public partial class frmBackupRestore : Form
    {
        string nombre = string.Empty;
        private string respuesta;

        public frmBackupRestore()
        {
            InitializeComponent();
            txtUserRegistro.Text = CE_UserLogin.Usuario;
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** PROCEDIMIENTO DEL BOTON BACKUP *****
        private void btnBackup_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            bool valor = new Backup().RealizarCopia();

            if (valor)
            {
                mensaje += "COPIA DE SEGURIDAD REALIZADA CON ÉXITO...!!!";
                frmMsgBox msgb = new frmMsgBox(mensaje, "ok", 1);
                DialogResult drb = msgb.ShowDialog();
            }
            else
            {
                mensaje += "NO SE PUEDO REALIZAR LA COPIA DE SEGURIDAD...VERIFIQUE...!!!";
                frmMsgBox msgb = new frmMsgBox(mensaje, "info", 1);
                DialogResult drb = msgb.ShowDialog();
            }
        }

        //***** BUSCO LA COPIA DE SEGURIDAD A RESTAURAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog file = new OpenFileDialog();
            string buscar = "PathBackup";
            string ruta = new LeerConfig().Proceso(buscar);
            file.InitialDirectory = ruta;
            file.DefaultExt = "Archivos sql (*.sql)|*.sql";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            file.Title = "SELECCIONAR LA COPIA DE SEGURIDAD";

            if (file.ShowDialog() == DialogResult.OK)
            {
                btnRestaurar.Enabled = true;
                nombre = file.FileName.ToString();
                nombre = Path.GetFileName(nombre);
                txtCopia.Text = nombre;
            }
        }

        //***** PROCEDIMIENTO PARA EL BOTON RESTAURAR *****
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "ESTÁ SEGURO DE REALIZAR LA RESTAURACIÓN DE LA COPIA DE SEGURIDAD...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            mensaje = string.Empty;

            if (respuesta == "OK")
            {
                bool valor = new Restaurar().RealizarRestore(nombre);

                if (valor)
                {
                    mensaje += "RESTAURACIÓN DE COPIA DE SEGURIDAD REALIZADA CON ÉXITO...!!!";
                    frmMsgBox msgr = new frmMsgBox(mensaje, "ok", 1);
                    DialogResult drr = msgr.ShowDialog();
                }
                else
                {
                    mensaje += "NO SE PUEDO REALIZAR LA RESTAURACIÓN DE LA COPIA DE SEGURIDAD...VERIFIQUE...!!!";
                    frmMsgBox msgr = new frmMsgBox(mensaje, "info", 1);
                    DialogResult drr = msgr.ShowDialog();
                }
            }
            else
            {
                mensaje += "UD. SUSPENDIÓ LA RESTAURACIÓN DE LA COPIA...!!!";
                frmMsgBox msgr = new frmMsgBox(mensaje, "info", 1);
                DialogResult drr = msgr.ShowDialog();
            }

            btnRestaurar.Enabled = false;
            txtCopia.Text = string.Empty;
        }
    }
}
