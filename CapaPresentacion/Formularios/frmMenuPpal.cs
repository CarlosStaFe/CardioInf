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
            pnlSubmenuColegiados.Visible = false;
            pnlSubmenuSociedades.Visible = false;
            pnlSubmenuCajaDiaria.Visible = false;
            pnlSubmenuMesaEntradas.Visible = false;
            pnlSubmenuProveedores.Visible = false;
            pnlSubmenuTesoreria.Visible = false;
            pnlSubmenuMantenedor.Visible = false;
            pnlSubmenuSistema.Visible = false;
        }

        private void OcultarSubmenu()
        {
            if (pnlSubmenuColegiados.Visible == true)
                pnlSubmenuColegiados.Visible = false;
            if (pnlSubmenuSociedades.Visible == true)
                pnlSubmenuSociedades.Visible = false;
            if (pnlSubmenuCajaDiaria.Visible == true)
                pnlSubmenuCajaDiaria.Visible = false;
            if (pnlSubmenuMesaEntradas.Visible == true)
                pnlSubmenuMesaEntradas.Visible = false;
            if (pnlSubmenuProveedores.Visible == true)
                pnlSubmenuProveedores.Visible = false;
            if (pnlSubmenuTesoreria.Visible == true)
                pnlSubmenuTesoreria.Visible = false;
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

        //***** MENÚ COLEGIADOS *****
        #region MENÚ COLEGIADOS
        private void btnColegiados_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuColegiados);
        }

        private void btnActualizarCol_Click_1(object sender, System.EventArgs e)
        {
            //AbrirFormHijo(new frmColegiados());
            //OcultarSubmenu();
        }

        #endregion

        //***** MENÚ SOCIEDADES *****
        #region MENÚ SOCIEDADES
        private void btnSociedades_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuSociedades);
        }

        private void btnActualizaSoc_Click(object sender, System.EventArgs e)
        {
        }

        #endregion

        //***** MENÚ CAJA DIARIA *****
        #region MENÚ CAJA DIARIA
        private void btnCajaDiaria_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuCajaDiaria);
        }
        private void btnCobrarPendientes_Click(object sender, System.EventArgs e)
        {
        }

        private void btnCobrarVarios_Click(object sender, System.EventArgs e)
        {
        }

        #endregion

        //***** MENÚ MESA DE ENTRADAS *****
        #region MENÚ MESA DE ENTRADAS
        private void btnMesaEntradas_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuMesaEntradas);
        }
        #endregion

        //***** MENÚ PROVEEDORES *****
        #region MENÚ PROVEEDORES 
        private void btnProveedores_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuProveedores);
        }
        #endregion

        //***** MENÚ TESORERÍA *****
        #region MENÚ TESORERÍA
        private void btnTesoreria_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuTesoreria);
        }
        #endregion

        //***** MENÚ MANTENEDOR *****
        #region MENÚ PARÁMETROS
        private void btnMantenedor_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuMantenedor);
        }
        private void btnCodPostales_Click_1(object sender, System.EventArgs e)
        {
        }

        private void btnDebitos_Click(object sender, System.EventArgs e)
        {
        }

        #endregion

        //***** MENÚ SISTEMA *****
        #region MENÚ SISTEMA
        private void btnSistema_Click(object sender, System.EventArgs e)
        {
            ActivarBoton(sender);
            MostrarSubmenu(pnlSubmenuSistema);
        }
        private void btnBackupRestore_Click(object sender, System.EventArgs e)
        {
        }
        private void btnUsuarios_Click_1(object sender, System.EventArgs e)
        {
        }
        private void btnBotones_Click(object sender, System.EventArgs e)
        {
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
