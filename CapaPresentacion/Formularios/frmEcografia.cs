using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmEcografia : Form
    {
        public frmEcografia()
        {
            InitializeComponent();
        }

        private void frmEcografia_Load(object sender, EventArgs e)
        {
            //LimpiarDatos();
            CargarCombos();

            txtDiagnostico.Focus();
        }

        //***** CARGO LOS COMBOS DE CADA ESTUDIO *****
        private void LimpiarDatos()
        {
            Limpiar limpiar = new Limpiar();
            limpiar.LimpiarCampos(this);
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** CARGO LOS COMBOS DE CADA ESTUDIO *****
        private void CargarCombos()
        {
            List<CE_Valores> ListaValores = new CN_Valores().ListaValores();

            foreach (CE_Valores item in ListaValores)
            {
                if (item.Estudio == "1. SITUS")
                {
                    cbo1.Items.Add(item.Valor);
                }

                if (item.Estudio == "2. POSICIÓN CARDÍACA")
                {
                    cbo2.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.1 AURICULA DERECHA")
                {
                    cbo31.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.2 AURÍCULA IZQUIERDA")
                {
                    cbo32.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.3 SEPTUM INTERAURICULAR")
                {
                    cbo33.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.4 VÁLVULAS A-V")
                {
                    cbo34.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.5 VENTRÍCULO DERECHO")
                {
                    cbo35.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.6 VENTRÍCULO IZQUIERDO")
                {
                    cbo36.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.7 SEPTUM INTERVENTRICULAR")
                {
                    cbo37.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.10 FA")
                {
                    cbo310.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.11 RETORNO VENOSO SISTÉMICO")
                {
                    cbo311.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.12 RETORNO VENOSO PULMONAR")
                {
                    cbo312.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.13 ARTERIA PULMONAR")
                {
                    cbo313.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.14 ARTERIA AORTA")
                {
                    cbo314.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.15 CAYADO AÓRTICO")
                {
                    cbo315.Items.Add(item.Valor);
                }

                if (item.Estudio == "3.16 PERICARDIO")
                {
                    cbo316.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.1 VÁLVULA TRICÚSPIDE")
                {
                    cbo41.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.2 VÁLVULA MITRAL")
                {
                    cbo42.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.3 TSVD")
                {
                    cbo43.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.4 VÁLVULA PULMONAR")
                {
                    cbo44.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.5 RAMAS PULMONARES")
                {
                    cbo45.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.6 TSVI")
                {
                    cbo46.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.7 VÁLVULA AÓRTICA")
                {
                    cbo47.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.8 AORTA ASCENDENTE")
                {
                    cbo48.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.9 AORTA DESCENDENTE")
                {
                    cbo49.Items.Add(item.Valor);
                }

                if (item.Estudio == "4.10 VENAS PULMONARES")
                {
                    cbo410.Items.Add(item.Valor);
                }

                if (item.Estudio == "5. EXÁMEN DOPPLER-COLOR")
                {
                    cbo5.Items.Add(item.Valor);
                }

                if (item.Estudio == "6. CONCLUSIÓN")
                {
                    cbo6.Items.Add(item.Valor);
                }
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
    }
}
