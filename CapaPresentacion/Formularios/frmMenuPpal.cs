using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Formularios;
using FontAwesome.Sharp;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace ColegMart
{
    public partial class frmMenuPpal : Form
    {
        private IconButton btnActual;
        private Panel pnlBorde;
        private Form activoForm = null;
        private Control formu;
        private int idUsuario;

        public frmMenuPpal()
        {
            InitializeComponent();
            pnlBorde = new Panel();
            pnlBorde.Size = new Size(111, 7);
            pnlMenu.Controls.Add(pnlBorde);
            Personalizar();

            //***** CAJA DEL FORMULARIO *****
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void frmMenuPpal_Load(object sender, System.EventArgs e)
        {
            LoadUsuario();

            //List<CE_Botones> BuscaBotones = new CN_Botones().BuscaBotones(idUsuario);

            //foreach (CE_Botones bot in BuscaBotones)
            //{
            //    formu = Controls.Find(bot.Nombre, true).FirstOrDefault();
            //    formu.Visible = true;
            //}
        }

        //***** MUESTRO USUARIO Y FUNCIÓN EN MENÚ *****
        private void LoadUsuario()
        {
            lblUsuario.Text = CE_UserLogin.Usuario + " - " + CE_UserLogin.Funcion;
            idUsuario = CE_UserLogin.id_Usuario;
        }

        //***** PROCESO PARA MOVER PANTALLA *****
        #region PROCESO PARA MOVER PANTALLA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        //***** BOTONES BARRA DE TÍTULO *****
        #region BOTONES BARRA TÍTULO
        private void btnCerrar_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnRestaurar.Visible = true;
                btnMaximizar.Visible = false;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnRestaurar.Visible = false;
                btnMaximizar.Visible = true;
            }
        }

        private void btnRestaurar_Click(object sender, System.EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                btnRestaurar.Visible = false;
                btnMaximizar.Visible = true;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                btnRestaurar.Visible = true;
                btnMaximizar.Visible = false;
            }
        }

        private void btnMinimizar_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        //***** PERSONALIZAMOS BOTÓN MENÚ *****
        #region BOTÓN MENÚ
        private void ActivarBoton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DesactivarBoton();
                CerrarFormulario();
                btnActual = (IconButton)senderBtn;
                btnActual.BackColor = Color.FromArgb(30,30,30);
                btnActual.ForeColor = Color.White;
                btnActual.IconColor = Color.Green;
                pnlBorde.BackColor = Color.Green;
                pnlBorde.Location = new Point(btnActual.Location.X, 101);
                pnlBorde.Visible = true;
                pnlBorde.BringToFront();
            }
        }

        private void DesactivarBoton()
        {
            if (btnActual != null)
            {
                btnActual.BackColor = Color.Black;
                btnActual.ForeColor = Color.White;
                btnActual.IconColor = Color.Cyan;
            }
        }
        #endregion

        //***** PRESIONAR EL LOGO *****
        #region PRESIONAR LOGO
        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            CerrarFormulario();
            Reset();
        }

        private void Reset()
        {
            DesactivarBoton();
            OcultarSubmenu();
            pnlBorde.Visible = false;
        }

        private void CerrarFormulario()
        {
            if (activoForm != null)
            {
                activoForm.Close();
            }
        }
        #endregion

        //***** PROCESOS DE SUBMENÚ *****
        #region SUBMENU
        private void Personalizar()
        {
            pnlSubmenuPacientes.Visible = false;
            pnlSubmenuConsultorio.Visible = false;
            pnlSubmenuObrasSociales.Visible = false;
            pnlSubmenuMantenedor.Visible = false;
            pnlSubmenuSistema.Visible = false;
        }

        private void OcultarSubmenu()
        {
            if (pnlSubmenuPacientes.Visible == true)
                pnlSubmenuPacientes.Visible = false;
            if (pnlSubmenuConsultorio.Visible == true)
                pnlSubmenuConsultorio.Visible = false;
            if (pnlSubmenuObrasSociales.Visible == true)
                pnlSubmenuObrasSociales.Visible = false;
            if (pnlSubmenuMantenedor.Visible == true)
                pnlSubmenuMantenedor.Visible = false;
            if (pnlSubmenuSistema.Visible == true)
                pnlSubmenuSistema.Visible = false;
        }

        private void MostrarSubmenu(Panel SubMenu)
        {
            if (SubMenu.Visible ==false)
            {
                OcultarSubmenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }
        #endregion

        //***** ABRIMOS FORMULARIOS HIJOS *****
        #region ABRIR FORMULARIOS
        private void AbrirFormHijo(Form formHijo)
        {
            if (activoForm != null)
                activoForm.Close();
            activoForm = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }
        #endregion

        //***** MENÚ PACIENTES *****
        #region MENÚ PACIENTES
        private void btnPacientes_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuPacientes);
        }

        private void btnActualizarPac_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmPacientes(0));
            OcultarSubmenu();
        }
        private void btnCargarAgenda_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmCargarAgenda());
            OcultarSubmenu();
        }
        private void btnVerEcografias_Click(object sender, System.EventArgs e)
        {
            //AbrirFormHijo(new frmVerEcografia());
            OcultarSubmenu();
        }
        private void btnEnviarMail_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmEnviarMail());
            OcultarSubmenu();
        }
        private void btnPlanificacion_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmPlanificacion());
            OcultarSubmenu();
        }

        #endregion

        //***** MENÚ CONSULTORIO *****
        #region MENÚ CONSULTORIO
        private void btnConsultorio_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuConsultorio);
        }
        private void btnAgenda_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmVerAgenda());
            OcultarSubmenu();
        }
        private void btnHistorias_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmHistorias(0));
            OcultarSubmenu();
        }

        #endregion

        //***** MENÚ OBRAS SOCIALES *****
        #region MENÚ OBRAS SOCIALES
        private void btnObrasSociales_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuObrasSociales);
        }
        private void btnActualizarOS_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmObrasSociales());
            OcultarSubmenu();
        }
        private void btnPlanesOS_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmPlanesOS());
            OcultarSubmenu();
        }

        #endregion

        //***** MENÚ MANTENEDOR *****
        #region MENÚ MANTENEDOR
        private void btnMantenedor_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuMantenedor);
        }
        private void btnBackupRestore_Click_1(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmBackupRestore());
            OcultarSubmenu();
        }
        private void btnCodPostales_Click_1(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmCodPostales());
            OcultarSubmenu();
        }
        private void btnProfesionales_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmProfesionales());
            OcultarSubmenu();
        }
        private void btnValores_Click_1(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmValores());
            OcultarSubmenu();
        }
        private void btnArrobas_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmArrobas());
            OcultarSubmenu();
        }


        #endregion

        //***** MENÚ SISTEMA *****
        #region MENÚ SISTEMA

        private void btnSistema_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuSistema);
        }
        private void btnUsuarios_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmUsuarios());
            OcultarSubmenu();
        }
        private void btnBotones_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmBotones());
            OcultarSubmenu();
        }
        private void btnPermisos_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmPermisos());
            OcultarSubmenu();
        }

        #endregion

        //***** MENÚ SALIR DEL SISTEMA *****
        #region MENÚ SALIR DEL SISTEMA

        private void btnSalir_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion

    }
}
