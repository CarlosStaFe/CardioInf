using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmEnviarMail : Form
    {
        string password = string.Empty;
        string mailorigen = string.Empty;
        string maildestino = string.Empty;
        string buscar = string.Empty;
        string linea = string.Empty;
        string path = string.Empty;
        string nombrePDF = string.Empty;
        string asunto = "Estudio realizado *** NO CONTESTAR ESTE MENSAJE ***";
        string mensaje = "Adjuntamos estudio realizado en nuestra clínica - NO CONTESTAR ESTE MENSAJE";
        private string estadolist;
        string estadoeco,fechaagenda;
        string fechaeco, senial;
        int id, numero;

        public frmEnviarMail()
        {
            InitializeComponent();
        }

        private void frmEnviarMail_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            fechaagenda = dtpFecha.Text;
            fechaagenda = new ProcesarFecha().Procesar(fechaagenda);

            CargarAgendas();
        }

        //***** PROCEDIMIENTO PARA CARGAR LAS AGENDAS SELECCIONADAS *****
        private void CargarAgendas()
        {
            dgvEcografias.Rows.Clear();

            List<CE_CabeceraEco> ListaCab = new CN_CabeceraEco().ListaCabEco(fechaagenda);

            //***** CARGO EL DGV *****
            foreach (CE_CabeceraEco item in ListaCab)
            {
                dgvEcografias.Rows.Add(new object[] { "", item.id_CabEco, item.Pacte, item.FechaEco, item.NumeroCab, item.ApelNombres,
                                                    item.Estado, item.FechaEstado, item.Tipo, item.Obs, item.UserRegistro, item.FechaRegistro });
            }

            Colorear();

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvEcografias.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvEcografias.Rows.Count; i++)
            {
                estadolist = Convert.ToString(dgvEcografias.Rows[i].Cells["Estado"].Value);

                if (estadolist == "EN ESPERA")
                {
                    dgvEcografias.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvEcografias.Rows[i].Cells["Estado"].Style.BackColor = Color.Aquamarine;
                }
                if (estadolist == "COMPLETA")
                {
                    dgvEcografias.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvEcografias.Rows[i].Cells["Estado"].Style.BackColor = Color.Green;
                }
                if (estadolist == "CONSULTORIO")
                {
                    dgvEcografias.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvEcografias.Rows[i].Cells["Estado"].Style.BackColor = Color.White;
                }
                if (estadolist == "CANCELADO")
                {
                    dgvEcografias.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvEcografias.Rows[i].Cells["Estado"].Style.BackColor = Color.Red;
                }
                if (estadolist == "ENVIADO")
                {
                    dgvEcografias.Rows[i].Cells["Estado"].Style.ForeColor = Color.Black;
                    dgvEcografias.Rows[i].Cells["Estado"].Style.BackColor = Color.Blue;
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvEcografias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        //***** MUEVO LO SELECCIONADO DEL DGV A LOS CAMPOS PARA MODIFICAR *****
        private void dgvEcografias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEcografias.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvEcografias.Rows[indice].Cells["id_CabEco"].Value.ToString();
                    txtPacte.Text = dgvEcografias.Rows[indice].Cells["Paciente"].Value.ToString();
                    lblApelNombres.Text = dgvEcografias.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                    txtNumeroEco.Text = dgvEcografias.Rows[indice].Cells["Numero"].Value.ToString();
                    numero = Convert.ToInt32(txtNumeroEco.Text);
                    lblFechaEco.Text = Convert.ToString(dgvEcografias.Rows[indice].Cells["Fecha"].Value.ToString());
                    fechaeco = lblFechaEco.Text;
                    int pos1 = lblFechaEco.Text.IndexOf(" ");
                    lblFechaEco.Text = lblFechaEco.Text.Substring(0, pos1);
                    txtUserRegistro.Text = dgvEcografias.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvEcografias.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                }
            }
        }

        //***** PROCESO PARA ENVIAR EL MAIL *****
        private void btnEnviarMail_Click(object sender, EventArgs e)
        {
            lblFechaEco.Text = lblFechaEco.Text.Replace("/", "-");

            string nro = new PonerCeros().Proceso(Convert.ToString(txtNumeroEco.Text), 8);

            buscar = "PathEcografias";
            linea = new LeerConfig().Proceso(buscar);
            nombrePDF = lblApelNombres.Text + "_" + nro + ".pdf";

            path = linea + nombrePDF;

            //***** BUSCAR MAIL DESTINO *****
            List<CE_Pacientes> ListaPac = new CN_Pacientes().BuscarPacte(txtPacte.Text);

            foreach (CE_Pacientes item in ListaPac)
            {
                maildestino = item.Email;
            }
            //maildestino = "carlos.a.mayans@gmail.com"; //***** MAIL DE PRUEBA *****

            buscar = "MailOrigen";
            mailorigen = new LeerConfig().Proceso(buscar);

            buscar = "PasswordMail";
            password = new LeerConfig().Proceso(buscar);

            bool enviado = new EnviarCorreo().EnviarMail(mailorigen, password, maildestino, asunto, mensaje, path);

            mensaje = "";

            if (enviado)
            {
                GrabarEstado();

                mensaje += "Email enviado correctamente...!!!";
                frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                msg1.ShowDialog();

                CargarAgendas();
            }
            else
            {
                mensaje += "EL MAIL NO FUE ENVIADO, VERIFIQUE...!!!";
                frmMsgBox msg1 = new frmMsgBox(mensaje, "question", 1);
                msg1.ShowDialog();
            }

            lblApelNombres.Text = String.Empty;
            lblFechaEco.Text = String.Empty;
        }

        //***** PROCESO PARA GRABAR EL NUEVO ESTADO DE LA AGENDA *****
        private void GrabarEstado()
        {
            estadoeco = "ENVIADO";
            id = Convert.ToInt32(txtId.Text);

            var okcab = new CN_CabeceraEco().ActualizoCabecera(id, estadoeco);

            var okagda = new CN_Agendas().ActualizoAgenda(id, estadoeco, numero);
        }

        //***** PROCESO PARA SELECCIONAR LA FECHA DE LAS ECOGRAFIAS *****
        private void dtpFecha_CloseUp(object sender, EventArgs e)
        {
            fechaagenda = dtpFecha.Text;
            fechaagenda = new ProcesarFecha().Procesar(fechaagenda);

            CargarAgendas();
        }

        //***** PROCESO PARA IMPRIMIR LA ECOGRAFÍA *****
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            lblFechaEco.Text = lblFechaEco.Text.Replace("/", "-");

            string nro = new PonerCeros().Proceso(Convert.ToString(txtNumeroEco.Text), 8);

            buscar = "PathEcografias";
            linea = new LeerConfig().Proceso(buscar);
            nombrePDF = lblApelNombres.Text + "_" + nro + ".pdf";

            path = linea + nombrePDF;

            nombrePDF = lblApelNombres.Text + "_" + nro;

            senial = "2";

            mdlInformeEco PrintEco = new mdlInformeEco(nombrePDF, nro, senial);
            AddOwnedForm(PrintEco);
            PrintEco.ShowDialog();
        }
    }
}
