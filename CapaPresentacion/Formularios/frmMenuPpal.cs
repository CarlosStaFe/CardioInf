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

            List<CE_Botones> BuscaBotones = new CN_Botones().BuscaBotones(idUsuario);

            foreach (CE_Botones bot in BuscaBotones)
            {
                formu = Controls.Find(bot.Nombre, true).FirstOrDefault();
                formu.Visible = true;
            }
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
            pnlSubmenuObraSocial.Visible = false;
            pnlSubmenuMantenedor.Visible = false;
            pnlSubmenuSistema.Visible = false;
        }

        private void OcultarSubmenu()
        {
            if (pnlSubmenuPacientes.Visible == true)
                pnlSubmenuPacientes.Visible = false;
            if (pnlSubmenuConsultorio.Visible == true)
                pnlSubmenuConsultorio.Visible = false;
            if (pnlSubmenuObraSocial.Visible == true)
                pnlSubmenuObraSocial.Visible = false;
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
        }

        #endregion

        //***** MENÚ CONSULTORIO *****
        #region MENÚ CONSULTORIO

        #endregion

        //***** MENÚ OBRA SOCIALES *****
        #region MENÚ OBRA SOCIALES

        #endregion

        //***** MENÚ MANTENEDOR *****
        #region MENÚ MANTENEDOR
        private void btnMantenedor_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuMantenedor);
        }

        private void btnProfesionales_Click(object sender, System.EventArgs e)
        {
            AbrirFormHijo(new frmProfesionales());
            OcultarSubmenu();
        }

        #endregion

        //***** MENÚ SISTEMA *****
        #region MENÚ SISTEMA

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
