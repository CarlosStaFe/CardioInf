using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmEcografia : Form
    {
        private string respuesta;
        string comprobante, tipoCpbte, idPaciente, obraSocial, planOS, afiliado, tipoEco, estado, numeroeco;
        string buscar, patheco, fechaeco, email, linea;
        int nrocpbte, dd, mm, aa, id;
        string nombrePDF;
        DateTime fechanacim, fechaestudio;
        SoloNumeros validar = new SoloNumeros();

        public frmEcografia(string paciente, string tipo, string fecha, int idAgda, string numero, string path)
        {
            idPaciente = paciente;
            tipoEco = tipo;

            fechaeco = fecha;
            fechaeco = new ProcesarFecha().Procesar(fechaeco);
            fechaestudio = Convert.ToDateTime(fecha);

            id = idAgda;
            numeroeco = numero;
            comprobante = numeroeco;
            patheco = path;

            InitializeComponent();
        }

        private void frmEcografia_Load(object sender, EventArgs e)
        {
            lblTipoEco.Text = tipoEco;
            dtpFecha.Text = fechaeco;

            CargarCombos();

            if (Convert.ToInt32(numeroeco) == 0)
            {
                LeerPaciente();
            }
            else
            {
                LeerPaciente();
                LeerEcografia();
            }

            txtDiagnostico.Focus();
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDiagnostico.Focus();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        //***** PROCEDIMIENTO PARA LEER EL PACIENTE ENVIADO *****
        private void LeerPaciente()
        {
            List<CE_Pacientes> BuscaPacte = new CN_Pacientes().BuscarPacte(idPaciente);

            foreach (CE_Pacientes item in BuscaPacte)
            {
                lblApelNombres.Text = item.ApelNombres.ToString();
                lblFecNacim.Text = item.FechaNacim.ToString();

                int pos1 = lblFecNacim.Text.IndexOf(" ");
                lblFecNacim.Text = lblFecNacim.Text.Substring(0, pos1);

                fechanacim = Convert.ToDateTime(item.FechaNacim.ToString());
                fechaestudio = Convert.ToDateTime(DateTime.Now.ToString());
                obraSocial = item.ObraSocial.ToString();
                planOS = item.PlanOS.ToString();
                afiliado = item.Afiliado.ToString();
                email = item.Email.ToString();

                CalculoEdades();

                lblAA.Text = aa.ToString();
                lblMM.Text = mm.ToString();
                lblDD.Text = dd.ToString();
            }
        }

        //***** PROCEDIMIENTO PARA LEER LA ECOGRAFÍA *****
        private void LeerEcografia()
        {
            List<CE_CabeceraEco> LeerCab = new CN_CabeceraEco().LeerCabecera(idPaciente, numeroeco);

            foreach (CE_CabeceraEco item in LeerCab)
            {
                lblApelNombres.Text = item.ApelNombres.ToString();
                lblFecNacim.Text = item.FechaNacim.ToString();

                int pos1 = lblFecNacim.Text.IndexOf(" ");
                lblFecNacim.Text = lblFecNacim.Text.Substring(0, pos1);

                fechanacim = Convert.ToDateTime(item.FechaNacim.ToString());
                fechaestudio = Convert.ToDateTime(item.FechaEco.ToString());
                obraSocial = item.ObraSocial.ToString();
                planOS = item.PlanOS.ToString();
                afiliado = item.Afiliado.ToString();

                CalculoEdades();

                lblAA.Text = aa.ToString();
                lblMM.Text = mm.ToString();
                lblDD.Text = dd.ToString();
            }

            List<CE_DetalleEco> LeerDet = new CN_DetalleEco().LeerDetalle(numeroeco);

            foreach (CE_DetalleEco item in LeerDet)
            {
                txtId.Text = item.id_DetEco.ToString();
                txtDiagnostico.Text = item.Diagnostico.ToString();
                txt1.Text = item.E1.ToString();
                txt2.Text = item.E2.ToString();
                txt31.Text = item.E31.ToString();
                txt32.Text = item.E32.ToString();
                txt33.Text = item.E33.ToString();
                txt34.Text = item.E34.ToString();
                txt35.Text = item.E35.ToString();
                txt36.Text = item.E36.ToString();
                txt37.Text = item.E37.ToString();
                txt38.Text = item.E38.ToString();
                txt39.Text = item.E39.ToString();
                cbo310.Text = item.E310.ToString();
                txt310p.Text = item.E310p.ToString();
                txt311.Text = item.E311.ToString();
                txt312.Text = item.E312.ToString();
                txt313.Text = item.E313.ToString();
                txt314.Text = item.E314.ToString();
                txt315.Text = item.E315.ToString();
                txt316.Text = item.E316.ToString();
                cbo41.Text = item.E41.ToString();
                txt41v.Text = item.E41v.ToString();
                txt41g.Text = item.E41g.ToString();
                cbo42.Text = item.E42.ToString();
                txt42v.Text = item.E42v.ToString();
                txt42g.Text = item.E42g.ToString();
                cbo43.Text = item.E43.ToString();
                txt43v.Text = item.E43v.ToString();
                txt43g.Text = item.E43g.ToString();
                cbo44.Text = item.E44.ToString();
                txt44v.Text = item.E44v.ToString();
                txt44g.Text = item.E44g.ToString();
                cbo45.Text = item.E45.ToString();
                txt45v.Text = item.E45v.ToString();
                txt45g.Text = item.E45g.ToString();
                cbo46.Text = item.E46.ToString();
                txt46v.Text = item.E46v.ToString();
                txt46g.Text = item.E46g.ToString();
                cbo47.Text = item.E47.ToString();
                txt47v.Text = item.E47v.ToString();
                txt47g.Text = item.E47g.ToString();
                cbo48.Text = item.E48.ToString();
                txt48v.Text = item.E48v.ToString();
                txt48g.Text = item.E48g.ToString();
                cbo49.Text = item.E49.ToString();
                txt49v.Text = item.E49v.ToString();
                txt49g.Text = item.E49g.ToString();
                cbo410.Text = item.E410.ToString();
                txt410v.Text = item.E410v.ToString();
                txt410g.Text = item.E410g.ToString();
                txt5.Text = item.E5.ToString();
                txt6.Text = item.E6.ToString();
            }
        }

        //***** CARGO LOS VALORES SELECCIONADOS A LOS TEXTOS *****
        private void cbo1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt1.Text = txt1.Text + cbo1.Text.ToString() + " - ";
        }

        private void cbo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt2.Text = txt2.Text + cbo2.Text.ToString() + " - ";
        }

        private void cbo31_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt31.Text = txt31.Text + cbo31.Text.ToString() + " - ";
        }

        private void cbo32_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt32.Text = txt32.Text + cbo32.Text.ToString() + " - ";
        }

        private void cbo33_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt33.Text = txt33.Text + cbo33.Text.ToString() + " - ";
        }

        private void cbo34_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt34.Text = txt34.Text + cbo34.Text.ToString() + " - ";
        }

        private void cbo35_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt35.Text = txt35.Text + cbo35.Text.ToString() + " - ";
        }

        private void cbo36_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt36.Text = txt36.Text + cbo36.Text.ToString() + " - ";
        }

        private void cbo37_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt37.Text = txt37.Text + cbo37.Text.ToString() + " - ";
        }

        private void cbo311_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt311.Text = txt311.Text + cbo311.Text.ToString() + " - ";
        }

        private void cbo312_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt312.Text = txt312.Text + cbo312.Text.ToString() + " - ";
        }

        private void cbo313_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt313.Text = txt313.Text + cbo313.Text.ToString() + " - ";
        }

        private void cbo314_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt314.Text = txt314.Text + cbo314.Text.ToString() + " - ";
        }

        private void cbo315_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt315.Text = txt315.Text + cbo315.Text.ToString() + " - ";
        }

        private void cbo316_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt316.Text = txt316.Text + cbo316.Text.ToString() + " - ";
        }

        private void cbo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt5.Text = txt5.Text + " * " + cbo5.Text.ToString();
        }

        private void cbo6_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt6.Text = txt6.Text + " * " + cbo6.Text.ToString();
        }

        //***** PROCEDIMIENTO PARA GRABAR LA ECOGRAFÍA *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTA ECOCARDIOGRAFÍA...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                fechaeco = dtpFecha.Text;
                fechaeco = new ProcesarFecha().Procesar(dtpFecha.Text);

                mensaje = string.Empty;

                MoverCeros();

                if (Convert.ToInt32(numeroeco) != 0)
                {
                    GrabarDetalle();
                    MostrarEcografia();
                }
                else
                {
                    tipoCpbte = "ECO";
                    BuscoComprobante();

                    //***** REGISTRO LA CEBACERA DE LA ECOGRAFÍA **********************************************

                    CE_CabeceraEco cE_CabeceraEco = new CE_CabeceraEco()
                    {
                        id_CabEco = Convert.ToInt32(txtId.Text),
                        Pacte = Convert.ToInt32(idPaciente),
                        FechaEco = Convert.ToDateTime(fechaeco),
                        NumeroCab = Convert.ToInt32(comprobante),
                        ApelNombres = lblApelNombres.Text,
                        FechaNacim = Convert.ToDateTime(lblFecNacim.Text),
                        ObraSocial = obraSocial,
                        PlanOS = planOS,
                        Afiliado = afiliado,
                        AA = aa,
                        MM = mm,
                        DD = dd,
                        Tipo = tipoEco,
                        Obs = email,
                        Estado = "COMPLETA",
                        FechaEstado = DateTime.Now,
                        UserRegistro = CE_UserLogin.Usuario,
                        FechaRegistro = DateTime.Now
                    };

                    //*****SI EL ID DE LA ECOGRAFÍA = 0 REGISTRA, SINO EDITA *****
                    if (cE_CabeceraEco.id_CabEco == 0)
                    {
                        int idCabEco = new CN_CabeceraEco().Registrar(cE_CabeceraEco, out mensaje);

                        if (idCabEco != 0)
                        {
                            GrabarDetalle();
                            MostrarEcografia();
                            comprobante = "";
                        }
                        else
                        {
                            mensaje += ". VERIFIQUE CABECERA...!!!";
                            frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                            msg1.ShowDialog();
                        }
                    }
                }
                mensaje += "ECOGRAFÍA GRABADA CORRECTAMENTE...!!!";
                frmMsgBox msg2 = new frmMsgBox(mensaje, "ok", 1);
                msg2.ShowDialog();
            }

            Close();
            Dispose();
        }

        //***** PROCESO PARA GRABAR EL DETALLE DE LA ECOGRAFÍA *****
        private void GrabarDetalle()
        {
            string mensaje = string.Empty;

            //***** REGISTRO EL DETALLE DE LA ECOGRAFÍA **********************************************
            CE_DetalleEco cE_DetalleEco = new CE_DetalleEco()
            {
                id_DetEco = Convert.ToInt32(txtId.Text),
                NumeroDet = Convert.ToInt32(comprobante),
                Diagnostico = txtDiagnostico.Text,
                E1 = txt1.Text,
                E2 = txt2.Text,
                E31 = txt31.Text,
                E32 = txt32.Text,
                E33 = txt33.Text,
                E34 = txt34.Text,
                E35 = txt35.Text,
                E36 = txt36.Text,
                E37 = txt37.Text,
                E38 = Convert.ToDecimal(txt38.Text),
                E39 = Convert.ToDecimal(txt39.Text),
                E310 = cbo310.Text,
                E310p = Convert.ToDecimal(txt310p.Text),
                E311 = txt311.Text,
                E312 = txt312.Text,
                E313 = txt313.Text,
                E314 = txt314.Text,
                E315 = txt315.Text,
                E316 = txt316.Text,
                E41 = cbo41.Text,
                E41v = Convert.ToDecimal(txt41v.Text),
                E41g = Convert.ToDecimal(txt41g.Text),
                E42 = cbo42.Text,
                E42v = Convert.ToDecimal(txt42v.Text),
                E42g = Convert.ToDecimal(txt42g.Text),
                E43 = cbo43.Text,
                E43v = Convert.ToDecimal(txt43v.Text),
                E43g = Convert.ToDecimal(txt43g.Text),
                E44 = cbo44.Text,
                E44v = Convert.ToDecimal(txt44v.Text),
                E44g = Convert.ToDecimal(txt44g.Text),
                E45 = cbo45.Text,
                E45v = Convert.ToDecimal(txt45v.Text),
                E45g = Convert.ToDecimal(txt45g.Text),
                E46 = cbo46.Text,
                E46v = Convert.ToDecimal(txt46v.Text),
                E46g = Convert.ToDecimal(txt46g.Text),
                E47 = cbo47.Text,
                E47v = Convert.ToDecimal(txt47v.Text),
                E47g = Convert.ToDecimal(txt47g.Text),
                E48 = cbo48.Text,
                E48v = Convert.ToDecimal(txt48v.Text),
                E48g = Convert.ToDecimal(txt48g.Text),
                E49 = cbo49.Text,
                E49v = Convert.ToDecimal(txt49v.Text),
                E49g = Convert.ToDecimal(txt49g.Text),
                E410 = cbo410.Text,
                E410v = Convert.ToDecimal(txt410v.Text),
                E410g = Convert.ToDecimal(txt410g.Text),
                E5 = txt5.Text,
                E6 = txt6.Text,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Now
            };

            //*****SI EL ID DE LA ECOGRAFÍA = 0 REGISTRA, SINO EDITA *****
            if (cE_DetalleEco.id_DetEco == 0)
            {
                int idDetEco = new CN_DetalleEco().Registrar(cE_DetalleEco, out mensaje);

                if (idDetEco != 0)
                {
                    CargarCombos();
                    GraboCpbte();
                    ActualizoAgenda();
                }
                else
                {
                    mensaje += ". VERIFIQUE DETALLE...!!!";
                    frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                    msg1.ShowDialog();
                }
            }
            else
            {
                bool resultado = new CN_DetalleEco().Editar(cE_DetalleEco, out mensaje);

                if (resultado)
                {
                    ActualizoAgenda();
                }
                else
                {
                    mensaje += ". VERIFIQUE DETALLE...!!!";
                    frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                    msg1.ShowDialog();
                }
            }
        }

        //***** CARGO LOS COMBOS DE CADA ESTUDIO *****
        private void CargarCombos()
        {
            dd = 0;
            mm = 0;
            aa = 0;

            LimpiarCombos();

            List<CE_Valores> ListaValores = new CN_Valores().ListaValores();

            foreach (CE_Valores item in ListaValores)
            {

                if (item.Estudio.Trim() == "1. SITUS")
                {
                    cbo1.Items.Add(item.Valor);
                    cbo1.SelectedIndex = -1;
                    txt1.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "2. POSICIÓN CARDÍACA")
                {
                    cbo2.Items.Add(item.Valor);
                    cbo2.SelectedIndex = -1;
                    txt2.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "3.1 AURICULA DERECHA")
                {
                    cbo31.Items.Add(item.Valor);
                    cbo31.SelectedIndex = -1;
                    txt31.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.2 AURÍCULA IZQUIERDA")
                {
                    cbo32.Items.Add(item.Valor);
                    cbo32.SelectedIndex = -1;
                    txt32.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.3 SEPTUM INTERAURICULAR")
                {
                    cbo33.Items.Add(item.Valor);
                    cbo33.SelectedIndex = -1;
                    txt33.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.4 VÁLVULAS A-V")
                {
                    cbo34.Items.Add(item.Valor);
                    cbo34.SelectedIndex = -1;
                    txt34.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.5 VENTRÍCULO DERECHO")
                {
                    cbo35.Items.Add(item.Valor);
                    cbo35.SelectedIndex = -1;
                    txt35.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.6 VENTRÍCULO IZQUIERDO")
                {
                    cbo36.Items.Add(item.Valor);
                    cbo36.SelectedIndex = -1;
                    txt36.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.7 SEPTUM INTERVENTRICULAR")
                {
                    cbo37.Items.Add(item.Valor);
                    cbo37.SelectedIndex = -1;
                    txt37.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.10 FA")
                {
                    cbo310.Items.Add(item.Valor);
                    cbo310.SelectedIndex = -1;
                    cbo310.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.11 RETORNO VENOSO SISTÉMICO")
                {
                    cbo311.Items.Add(item.Valor);
                    cbo311.SelectedIndex = -1;
                    txt311.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.12 RETORNO VENOSO PULMONAR")
                {
                    cbo312.Items.Add(item.Valor);
                    cbo312.SelectedIndex = -1;
                    txt312.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.13 ARTERIA PULMONAR")
                {
                    cbo313.Items.Add(item.Valor);
                    cbo313.SelectedIndex = -1;
                    txt313.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.14 ARTERIA AORTA")
                {
                    cbo314.Items.Add(item.Valor);
                    cbo314.SelectedIndex = -1;
                    txt314.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.15 CAYADO AÓRTICO")
                {
                    cbo315.Items.Add(item.Valor);
                    cbo315.SelectedIndex = -1;
                    txt315.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "3.16 PERICARDIO")
                {
                    cbo316.Items.Add(item.Valor);
                    cbo316.SelectedIndex = -1;
                    txt316.Text = "Normal - ";
                }

                if (item.Estudio.Trim() == "4.1 VÁLVULA TRICÚSPIDE")
                {
                    cbo41.Items.Add(item.Valor);
                    cbo41.SelectedIndex = -1;
                    cbo41.Text = "Normal";
                    txt41v.Text = string.Empty;
                    txt41g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.2 VÁLVULA MITRAL")
                {
                    cbo42.Items.Add(item.Valor);
                    cbo42.SelectedIndex = -1;
                    cbo42.Text = "Normal";
                    txt42v.Text = string.Empty;
                    txt42g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.3 TSVD")
                {
                    cbo43.Items.Add(item.Valor);
                    cbo43.SelectedIndex = -1;
                    cbo43.Text = "Normal";
                    txt43v.Text = string.Empty;
                    txt43g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.4 VÁLVULA PULMONAR")
                {
                    cbo44.Items.Add(item.Valor);
                    cbo44.SelectedIndex = -1;
                    cbo44.Text = "Normal";
                    txt44v.Text = string.Empty;
                    txt44g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.5 RAMAS PULMONARES")
                {
                    cbo45.Items.Add(item.Valor);
                    cbo45.SelectedIndex = -1;
                    cbo45.Text = "Normal";
                    txt45v.Text = string.Empty;
                    txt45g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.6 TSVI")
                {
                    cbo46.Items.Add(item.Valor);
                    cbo46.SelectedIndex = -1;
                    cbo46.Text = "Normal";
                    txt46v.Text = string.Empty;
                    txt46g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.7 VÁLVULA AÓRTICA")
                {
                    cbo47.Items.Add(item.Valor);
                    cbo47.SelectedIndex = -1;
                    cbo47.Text = "Normal";
                    txt47v.Text = string.Empty;
                    txt47g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.8 AORTA ASCENDENTE")
                {
                    cbo48.Items.Add(item.Valor);
                    cbo48.SelectedIndex = -1;
                    cbo48.Text = "Normal";
                    txt48v.Text = string.Empty;
                    txt48g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.9 AORTA DESCENDENTE")
                {
                    cbo49.Items.Add(item.Valor);
                    cbo49.SelectedIndex = -1;
                    cbo49.Text = "Normal";
                    txt49v.Text = string.Empty;
                    txt49g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "4.10 VENAS PULMONARES")
                {
                    cbo410.Items.Add(item.Valor);
                    cbo410.SelectedIndex = -1;
                    cbo410.Text = "Normal";
                    txt410v.Text = string.Empty;
                    txt410g.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "5. EXÁMEN DOPPLER-COLOR")
                {
                    cbo5.Items.Add(item.Valor);
                    cbo5.SelectedIndex = -1;
                    txt5.Text = string.Empty;
                }

                if (item.Estudio.Trim() == "6. CONCLUSIÓN")
                {
                    cbo6.Items.Add(item.Valor);
                    cbo6.SelectedIndex = -1;
                    txt6.Text = string.Empty;
                }
            }
        }

        //***** LIMPIO LOS DATOS DE LA PANTALLA *****
        private void LimpiarCombos()
        {
            txtDiagnostico.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt38.Text = string.Empty;
            txt39.Text = string.Empty;
            txt310p.Text = string.Empty;
            txt41g.Text = string.Empty;
            txt41v.Text = string.Empty;
            txt42g.Text = string.Empty;
            txt42v.Text = string.Empty;
            txt43g.Text = string.Empty;
            txt43v.Text = string.Empty;
            txt44g.Text = string.Empty;
            txt44v.Text = string.Empty;
            txt45g.Text = string.Empty;
            txt45v.Text = string.Empty;
            txt46g.Text = string.Empty;
            txt46v.Text = string.Empty;
            txt47g.Text = string.Empty;
            txt47v.Text = string.Empty;
            txt48g.Text = string.Empty;
            txt48v.Text = string.Empty;
            txt49g.Text = string.Empty;
            txt49v.Text = string.Empty;
            txt410g.Text = string.Empty;
            txt410v.Text = string.Empty;
            txt5.Text = string.Empty;
            txt6.Text = string.Empty;
            cbo1.Items.Clear();
            cbo1.Text = string.Empty;
            cbo2.Items.Clear();
            cbo2.Text = string.Empty;
            cbo31.Items.Clear();
            cbo31.Text = string.Empty;
            cbo32.Items.Clear();
            cbo32.Text = string.Empty;
            cbo33.Items.Clear();
            cbo33.Text = string.Empty;
            cbo34.Items.Clear();
            cbo34.Text = string.Empty;
            cbo35.Items.Clear();
            cbo35.Text = string.Empty;
            cbo36.Items.Clear();
            cbo36.Text = string.Empty;
            cbo37.Items.Clear();
            cbo37.Text = string.Empty;
            cbo310.Items.Clear();
            cbo310.Text = string.Empty;
            cbo311.Items.Clear();
            cbo311.Text = string.Empty;
            cbo312.Items.Clear();
            cbo312.Text = string.Empty;
            cbo313.Items.Clear();
            cbo313.Text = string.Empty;
            cbo314.Items.Clear();
            cbo314.Text = string.Empty;
            cbo315.Items.Clear();
            cbo315.Text = string.Empty;
            cbo316.Items.Clear();
            cbo316.Text = string.Empty;
            cbo41.Items.Clear();
            cbo41.Text = string.Empty;
            cbo42.Items.Clear();
            cbo42.Text = string.Empty;
            cbo43.Items.Clear();
            cbo43.Text = string.Empty;
            cbo44.Items.Clear();
            cbo44.Text = string.Empty;
            cbo45.Items.Clear();
            cbo45.Text = string.Empty;
            cbo46.Items.Clear();
            cbo46.Text = string.Empty;
            cbo47.Items.Clear();
            cbo47.Text = string.Empty;
            cbo48.Items.Clear();
            cbo48.Text = string.Empty;
            cbo49.Items.Clear();
            cbo49.Text = string.Empty;
            cbo410.Items.Clear();
            cbo410.Text = string.Empty;
            cbo5.Items.Clear();
            cbo5.Text = string.Empty;
            cbo6.Items.Clear();
            cbo6.Text = string.Empty;
        }

        //***** VALIDO EL INGRESO DE NÚMERO SOLAMENTE *****
        private void txt38_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt39_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt310p_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt41v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt41g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt42v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt42g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt43v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt43g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt44v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt44g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt45v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt45g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt46v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt46g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt47v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt47g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt48v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt48g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt49v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt49g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt410v_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        private void txt410g_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** MUEVO 0 DONDE HAY ESPACIOS EN BLANCO *****
        private void MoverCeros()
        {
            if (txt38.Text == "")
            {
                txt38.Text = "0";
            }
            if (txt39.Text == "")
            {
                txt39.Text = "0";
            }
            if (txt310p.Text == "")
            {
                txt310p.Text = "0";
            }
            if (txt41v.Text == "")
            {
                txt41v.Text = "0";
            }
            if (txt41g.Text == "")
            {
                txt41g.Text = "0";
            }
            if (txt42v.Text == "")
            {
                txt42v.Text = "0";
            }
            if (txt42g.Text == "")
            {
                txt42g.Text = "0";
            }
            if (txt43v.Text == "")
            {
                txt43v.Text = "0";
            }
            if (txt43g.Text == "")
            {
                txt43g.Text = "0";
            }
            if (txt44v.Text == "")
            {
                txt44v.Text = "0";
            }
            if (txt44g.Text == "")
            {
                txt44g.Text = "0";
            }
            if (txt45v.Text == "")
            {
                txt45v.Text = "0";
            }
            if (txt45g.Text == "")
            {
                txt45g.Text = "0";
            }
            if (txt46v.Text == "")
            {
                txt46v.Text = "0";
            }
            if (txt46g.Text == "")
            {
                txt46g.Text = "0";
            }
            if (txt47v.Text == "")
            {
                txt47v.Text = "0";
            }
            if (txt47g.Text == "")
            {
                txt47g.Text = "0";
            }
            if (txt48v.Text == "")
            {
                txt48v.Text = "0";
            }
            if (txt48g.Text == "")
            {
                txt48g.Text = "0";
            }
            if (txt49v.Text == "")
            {
                txt49v.Text = "0";
            }
            if (txt49g.Text == "")
            {
                txt49g.Text = "0";
            }
            if (txt410v.Text == "")
            {
                txt410v.Text = "0";
            }
            if (txt410g.Text == "")
            {
                txt410g.Text = "0";
            }
        }

        //***** BUSCO EL NÚMERO DE COMPROBANTE DE LA LIQUIDACIÓN *****
        private void BuscoComprobante()
        {
            nrocpbte = new CN_Comprobantes().BuscoCpbte(tipoCpbte);
            comprobante = Convert.ToString(nrocpbte + 1);
            comprobante = new PonerCeros().Proceso(comprobante, 8);
        }

        //***** PROCESO PARA GRABAR EL NÚMERO DE COMPROBANTE UTILIZADO *****
        private void GraboCpbte()
        {
            nrocpbte = Convert.ToInt32(comprobante);
            var ok = new CN_Comprobantes().GraboCpbte(tipoCpbte, nrocpbte);
        }

        //***** PROCESO PARA GRABAR EL NUEVO ESTADO DE LA AGENDA *****
        private void ActualizoAgenda()
        {
            estado = "COMPLETA";
            nrocpbte = Convert.ToInt32(comprobante);
            var ok = new CN_Agendas().ActualizoAgenda(id, estado, nrocpbte);
        }

        //***** PROCESO PARA CALCULAR LA EDAD DE LOS PACIENTES *****
        private void CalculoEdades()
        {
            Tuple<int, int, int> CalcularEdad(DateTime fechaestudio, DateTime fechanacim)
            {
                var ts = fechaestudio - fechanacim;
                DateTime dt = new DateTime(ts.Ticks).AddYears(1).AddMonths(-1).AddDays(-1);
                return new Tuple<int, int, int>(dt.Year - 2, dt.Month, dt.Day);
            };

            aa = CalcularEdad(fechaestudio, fechanacim).Item1;
            mm = CalcularEdad(fechaestudio, fechanacim).Item2;
            dd = CalcularEdad(fechaestudio, fechanacim).Item3;

            if (aa < 0) aa = 0;
            if (mm == 12) mm = 0;
        }

        //***** MUESTRO LA ECOGRAFÍA CARGADA *****
        private void MostrarEcografia()
        {
            fechaeco = fechaeco.Replace("/", "-");

            string nro = new PonerCeros().Proceso(Convert.ToString(comprobante), 8);

            buscar = "PathEcografias";
            linea = new LeerConfig().Proceso(buscar);
            nombrePDF = lblApelNombres.Text + "_" + nro + ".pdf";

            patheco = linea + nombrePDF;

            nombrePDF = lblApelNombres.Text + "_" + nro;

            string senial = "1";

            mdlInformeEco PrintEco = new mdlInformeEco(nombrePDF, comprobante, senial);
            AddOwnedForm(PrintEco);
            PrintEco.ShowDialog();
        }
    }
}
