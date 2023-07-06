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
        SoloNumeros validar = new SoloNumeros();

        public frmEcografia()
        {
            InitializeComponent();
        }

        private void frmEcografia_Load(object sender, EventArgs e)
        {
            LimpiarCombos();
            CargarCombos();

            txtDiagnostico.Focus();
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarCombos();
            CargarCombos();

            txtDiagnostico.Focus();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
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

            txtPacte.Text = "1";
            txtOS.Text = "123";
            txtPlan.Text = "321";
            int numero = 1253;

            mensaje += "DESEA REGISTRAR ESTA ECOCARDIOGRAFÍA...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                MoverCeros();

                CE_Ecografias cE_Ecografias = new CE_Ecografias()
                {
                    id_Eco = Convert.ToInt32(txtId.Text),
                    Pacte = Convert.ToInt32(txtPacte.Text),
                    Numero = numero,
                    OS = Convert.ToInt32(txtOS.Text),
                    PlanOS = Convert.ToInt32(txtPlan.Text),
                    FechaEco = DateTime.Now,
                    AA = 12,
                    MM = 10,
                    DD = 5,
                    Tipo = "Fetal",
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
                if (cE_Ecografias.id_Eco == 0)
                {
                    int idEcografia = new CN_Ecografias().Registrar(cE_Ecografias, out mensaje);

                    if (idEcografia != 0)
                    {
                        LimpiarCombos();
                        CargarCombos();

                        txtDiagnostico.Focus();
                    }
                    else
                    {
                        mensaje += ". VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
                }
                else
                {
                    bool resultado = new CN_Ecografias().Editar(cE_Ecografias, out mensaje);

                    if (resultado)
                    {
                        LimpiarCombos();
                        CargarCombos();

                        txtDiagnostico.Focus();
                    }
                    else
                    {
                        mensaje += ". VERIFIQUE...!!!";
                        frmMsgBox msg1 = new frmMsgBox(mensaje, "info", 1);
                        msg1.ShowDialog();
                    }
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

        //***** CARGO LOS COMBOS DE CADA ESTUDIO *****
        private void CargarCombos()
        {
            LimpiarCombos();

            List<CE_Valores> ListaValores = new CN_Valores().ListaValores();

            foreach (CE_Valores item in ListaValores)
            {
                if (item.Estudio == "1. SITUS")
                {
                    cbo1.Items.Add(item.Valor);
                    cbo1.SelectedIndex = -1;
                    txt1.Text = string.Empty;
                }

                if (item.Estudio == "2. POSICIÓN CARDÍACA")
                {
                    cbo2.Items.Add(item.Valor);
                    cbo2.SelectedIndex = -1;
                    txt2.Text = string.Empty;
                }

                if (item.Estudio == "3.1 AURICULA DERECHA")
                {
                    cbo31.Items.Add(item.Valor);
                    cbo31.SelectedIndex = -1;
                    txt31.Text = "Normal - ";
                }

                if (item.Estudio == "3.2 AURÍCULA IZQUIERDA")
                {
                    cbo32.Items.Add(item.Valor);
                    cbo32.SelectedIndex = -1;
                    txt32.Text = "Normal - ";
                }

                if (item.Estudio == "3.3 SEPTUM INTERAURICULAR")
                {
                    cbo33.Items.Add(item.Valor);
                    cbo33.SelectedIndex = -1;
                    txt33.Text = "Normal - ";
                }

                if (item.Estudio == "3.4 VÁLVULAS A-V")
                {
                    cbo34.Items.Add(item.Valor);
                    cbo34.SelectedIndex = -1;
                    txt34.Text = "Normal - ";
                }

                if (item.Estudio == "3.5 VENTRÍCULO DERECHO")
                {
                    cbo35.Items.Add(item.Valor);
                    cbo35.SelectedIndex = -1;
                    txt35.Text = "Normal - ";
                }

                if (item.Estudio == "3.6 VENTRÍCULO IZQUIERDO")
                {
                    cbo36.Items.Add(item.Valor);
                    cbo36.SelectedIndex = -1;
                    txt36.Text = "Normal - ";
                }

                if (item.Estudio == "3.7 SEPTUM INTERVENTRICULAR")
                {
                    cbo37.Items.Add(item.Valor);
                    cbo37.SelectedIndex = -1;
                    txt37.Text = "Normal - ";
                }

                if (item.Estudio == "3.10 FA")
                {
                    cbo310.Items.Add(item.Valor);
                    cbo310.SelectedIndex = -1;
                    cbo310.Text = "Normal - ";
                }

                if (item.Estudio == "3.11 RETORNO VENOSO SISTÉMICO")
                {
                    cbo311.Items.Add(item.Valor);
                    cbo311.SelectedIndex = -1;
                    txt311.Text = "Normal - ";
                }

                if (item.Estudio == "3.12 RETORNO VENOSO PULMONAR")
                {
                    cbo312.Items.Add(item.Valor);
                    cbo312.SelectedIndex = -1;
                    txt312.Text = "Normal - ";
                }

                if (item.Estudio == "3.13 ARTERIA PULMONAR")
                {
                    cbo313.Items.Add(item.Valor);
                    cbo313.SelectedIndex = -1;
                    txt313.Text = "Normal - ";
                }

                if (item.Estudio == "3.14 ARTERIA AORTA")
                {
                    cbo314.Items.Add(item.Valor);
                    cbo314.SelectedIndex = -1;
                    txt314.Text = "Normal - ";
                }

                if (item.Estudio == "3.15 CAYADO AÓRTICO")
                {
                    cbo315.Items.Add(item.Valor);
                    cbo315.SelectedIndex = -1;
                    txt315.Text = "Normal - ";
                }

                if (item.Estudio == "3.16 PERICARDIO")
                {
                    cbo316.Items.Add(item.Valor);
                    cbo316.SelectedIndex = -1;
                    txt316.Text = "Normal - ";
                }

                if (item.Estudio == "4.1 VÁLVULA TRICÚSPIDE")
                {
                    cbo41.Items.Add(item.Valor);
                    cbo41.SelectedIndex = -1;
                    cbo41.Text = "Normal";
                    txt41v.Text = string.Empty;
                    txt41g.Text = string.Empty;
                }

                if (item.Estudio == "4.2 VÁLVULA MITRAL")
                {
                    cbo42.Items.Add(item.Valor);
                    cbo42.SelectedIndex = -1;
                    cbo42.Text = "Normal";
                    txt42v.Text = string.Empty;
                    txt42g.Text = string.Empty;
                }

                if (item.Estudio == "4.3 TSVD")
                {
                    cbo43.Items.Add(item.Valor);
                    cbo43.SelectedIndex = -1;
                    cbo43.Text = "Normal";
                    txt43v.Text = string.Empty;
                    txt43g.Text = string.Empty;
                }

                if (item.Estudio == "4.4 VÁLVULA PULMONAR")
                {
                    cbo44.Items.Add(item.Valor);
                    cbo44.SelectedIndex = -1;
                    cbo44.Text = "Normal";
                    txt44v.Text = string.Empty;
                    txt44g.Text = string.Empty;
                }

                if (item.Estudio == "4.5 RAMAS PULMONARES")
                {
                    cbo45.Items.Add(item.Valor);
                    cbo45.SelectedIndex = -1;
                    cbo45.Text = "Normal";
                    txt45v.Text = string.Empty;
                    txt45g.Text = string.Empty;
                }

                if (item.Estudio == "4.6 TSVI")
                {
                    cbo46.Items.Add(item.Valor);
                    cbo46.SelectedIndex = -1;
                    cbo46.Text = "Normal";
                    txt46v.Text = string.Empty;
                    txt46g.Text = string.Empty;
                }

                if (item.Estudio == "4.7 VÁLVULA AÓRTICA")
                {
                    cbo47.Items.Add(item.Valor);
                    cbo47.SelectedIndex = -1;
                    cbo47.Text = "Normal";
                    txt47v.Text = string.Empty;
                    txt47g.Text = string.Empty;
                }

                if (item.Estudio == "4.8 AORTA ASCENDENTE")
                {
                    cbo48.Items.Add(item.Valor);
                    cbo48.SelectedIndex = -1;
                    cbo48.Text = "Normal";
                    txt48v.Text = string.Empty;
                    txt48g.Text = string.Empty;
                }

                if (item.Estudio == "4.9 AORTA DESCENDENTE")
                {
                    cbo49.Items.Add(item.Valor);
                    cbo49.SelectedIndex = -1;
                    cbo49.Text = "Normal";
                    txt49v.Text = string.Empty;
                    txt49g.Text = string.Empty;
                }

                if (item.Estudio == "4.10 VENAS PULMONARES")
                {
                    cbo410.Items.Add(item.Valor);
                    cbo410.SelectedIndex = -1;
                    cbo410.Text = "Normal";
                    txt410v.Text = string.Empty;
                    txt410g.Text = string.Empty;
                }

                if (item.Estudio == "5. EXÁMEN DOPPLER-COLOR")
                {
                    cbo5.Items.Add(item.Valor);
                    cbo5.SelectedIndex = -1;
                    txt5.Text = string.Empty;
                }

                if (item.Estudio == "6. CONCLUSIÓN")
                {
                    cbo6.Items.Add(item.Valor);
                    cbo6.SelectedIndex = -1;
                    txt6.Text = string.Empty;
                }
            }
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            mdlPrintEcografia Comun = new mdlPrintEcografia();
            //Comun.detalle = detalle;
            //Comun.user = txtUserRegistro.Text;
            Comun.ShowDialog();
        }

    }



}
