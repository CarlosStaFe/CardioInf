using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmPacientes : Form
    {
        private string respuesta;
        private string mensaje;
        string nombreOS;
        string mail;
        int id;
        string texto = "";
        SoloNumeros validar = new SoloNumeros();

        int codpos = 0;
        public string localidad;

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, System.EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;

            Limpiar();
            CargarComboOS();
            CargarArrobas();
            CargarDGV();

            //Colorear();

            cboTipoDoc.Select();
        }

        private void CargarDGV()
        {
            List<CE_Pacientes> ListaPac = new CN_Pacientes().ListaPacte(texto);

            //***** CARGO EL DGV *****
            foreach (CE_Pacientes item in ListaPac)
            {
                dgvPacientes.Rows.Add(new object[] { "", item.id_Pacte, item.ApelNombres, item.FechaNacim, item.Sexo, item.TipoDoc, item.NumeroDoc, item.Domicilio, item.CodPostal,
                                                item.Telefono, item.Email, item.ObraSocial, item.PlanOS, item.Obs, item.UserRegistro, item.FechaRegistro, item.Afiliado });
            }
        }

        //***** COLOREO LA CELDA SI LA FIANZA ESTÁ VENCIDA *****
        private void Colorear()
        {
            for (int i = 0; i < dgvPacientes.Rows.Count; i++)
            {
                DateTime dateFecha = Convert.ToDateTime(dgvPacientes.Rows[i].Cells["FecEstado"].Value);
            }
        }

        //***** PROCEDIMIENTO DEL BOTON CLEAR DE DATOS *****
        private void btnClear_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON SALIR *****
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        //***** LIMPIO LOS DATOS DE INGRESO *****
        private void Limpiar()
        {
            txtId.Text = "0";
            cboTipoDoc.Text = "DNI";
            txtNumeroDoc.Text = String.Empty;
            txtApelNombres.Text = String.Empty;
            cboSexo.Text = String.Empty;
            dtpFechaNacim.Value = DateTime.Now;
            txtDomicilio.Text = String.Empty;
            lblLocalidad.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            txtEmail.Text = String.Empty;
            cboObraSocial.Text = String.Empty;
            cboPlanOS.Text = String.Empty;
            txtObs.Text = String.Empty;
            txtAfiliado.Text = String.Empty;

            cboTipoDoc.Select();
        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvPacientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPacientes.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvPacientes.Rows[indice].Cells["id_Pacte"].Value.ToString();
                    txtApelNombres.Text = dgvPacientes.Rows[indice].Cells["ApellidoyNombres"].Value.ToString();
                    dtpFechaNacim.Value = Convert.ToDateTime(dgvPacientes.Rows[indice].Cells["FechaNacim"].Value.ToString());
                    cboSexo.Text = dgvPacientes.Rows[indice].Cells["Sexo"].Value.ToString();
                    cboTipoDoc.Text = dgvPacientes.Rows[indice].Cells["Tipo"].Value.ToString();
                    txtNumeroDoc.Text = dgvPacientes.Rows[indice].Cells["Numero"].Value.ToString();
                    txtDomicilio.Text = dgvPacientes.Rows[indice].Cells["Domicilio"].Value.ToString();
                    txtCodPos.Text = dgvPacientes.Rows[indice].Cells["CodPostal"].Value.ToString();

                    //***** BUSCO LA LOCALIDAD DEL PACIENTE *****
                    codpos = Convert.ToInt32(txtCodPos.Text);
                    localidad = new CN_CodigosPostales().BuscaCodPos(codpos);
                    lblLocalidad.Text = localidad.ToString();

                    txtTelefono.Text = dgvPacientes.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtEmail.Text = dgvPacientes.Rows[indice].Cells["Email"].Value.ToString();
                    cboObraSocial.Text = dgvPacientes.Rows[indice].Cells["ObraSocial"].Value.ToString();
                    cboPlanOS.Text = dgvPacientes.Rows[indice].Cells["PlanOS"].Value.ToString();
                    txtObs.Text = dgvPacientes.Rows[indice].Cells["Obs"].Value.ToString();
                    txtUserRegistro.Text = dgvPacientes.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvPacientes.Rows[indice].Cells["FechaRegistro"].Value.ToString();
                    txtAfiliado.Text = dgvPacientes.Rows[indice].Cells["Afiliado"].Value.ToString();
                }
            }
        }

        //***** PROCEDIMIENTO DEL BOTON BUSCAR *****
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPacientes.Rows.Clear();

            texto = txtFiltro.Text;

            CargarDGV();
        }

        //***** PROCEDIMIENTO DEL BOTON LIMPIAR BUSQUEDA *****
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            texto = txtFiltro.Text;
            dgvPacientes.Rows.Clear();
            CargarDGV();
            Limpiar();
        }

        //***** PROCEDIMIENTO DEL BOTON PARA BUSCAR LA LOCALIDAD *****
        private void btnLocalidad_Click(object sender, EventArgs e)
        {
            mdlCodPostal CodigoPostal = new mdlCodPostal("btnLocalPacte");
            AddOwnedForm(CodigoPostal);
            CodigoPostal.ShowDialog();
        }

        //***** CARGO EL COMBO DE LAS OBRAS SOCIALES Y PLANES *****
        private void CargarComboOS()
        {
            cboObraSocial.Items.Clear();
            cboObraSocial.Text = string.Empty;

            List<CE_ObrasSociales> ListaOS = new CN_ObrasSociales().ListaOS();

            foreach (CE_ObrasSociales item in ListaOS)
            {
                cboObraSocial.Items.Add(item.Nombre);
                cboObraSocial.SelectedIndex = -1;
            }
        }

        //***** SELECCIONO LA OS *****
        private void cboObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreOS = cboObraSocial.Text.ToString();
            CargarPlanOS();
        }

        //***** CARGO EL COMBO DE LOS PLANES DE LA OBRA SOCIAL ELEJIDA *****
        private void CargarPlanOS()
        {
            cboPlanOS.Items.Clear();
            cboPlanOS.Text = string.Empty;

            List<CE_PlanesOS> ListaPlan = new CN_PlanesOS().ListaPlan(nombreOS, out mensaje);

            foreach (CE_PlanesOS item in ListaPlan)
            {
                cboPlanOS.Items.Add(item.NombrePlan);
                cboPlanOS.SelectedIndex = -1;
            }
        }

        //***** PROCEDIMIENTO DEL BOTON GUARDAR *****
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            mensaje += "DESEA REGISTRAR ESTE PACIENTE...???";
            frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
            DialogResult dr = msg.ShowDialog();
            respuesta = dr.ToString();

            if (respuesta == "OK")
            {
                mail = txtEmail.Text;
                id = Convert.ToInt32(txtId.Text);

                CE_Pacientes cE_Pacientes = new CE_Pacientes()
                {
                    id_Pacte = Convert.ToInt32(txtId.Text),
                    ApelNombres = txtApelNombres.Text,
                    FechaNacim = dtpFechaNacim.Value,
                    Sexo = cboSexo.Text,
                    TipoDoc = cboTipoDoc.Text,
                    NumeroDoc = Convert.ToInt32(txtNumeroDoc.Text),
                    Domicilio = txtDomicilio.Text,
                    CodPostal = Convert.ToInt32(txtCodPos.Text),
                    Telefono = txtTelefono.Text,
                    Email = txtEmail.Text,
                    ObraSocial = cboObraSocial.Text,
                    PlanOS = cboPlanOS.Text,
                    Obs = txtObs.Text,
                    UserRegistro = CE_UserLogin.Usuario,
                    FechaRegistro = DateTime.Today,
                    Afiliado = txtAfiliado.Text
                };

                //***** SI EL ID DEL PACIENTE = 0 REGISTRA, SINO EDITA *****
                if (cE_Pacientes.id_Pacte == 0)
                {
                    int idPacte = new CN_Pacientes().Registrar(cE_Pacientes, out mensaje);

                    if (idPacte != 0)
                    {
                        dgvPacientes.Rows.Add(new object[] {"",idPacte,txtApelNombres.Text,dtpFechaNacim.Text,cboSexo.Text,cboTipoDoc.Text,txtNumeroDoc.Text,txtDomicilio.Text,
                                                    txtCodPos.Text, txtTelefono.Text,txtEmail.Text,cboObraSocial.Text,cboPlanOS.Text,txtObs.Text,txtUserRegistro.Text,txtFechaRegistro.Text,txtAfiliado.Text});
                        Limpiar();
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
                    bool resultado = new CN_Pacientes().Editar(cE_Pacientes, out mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvPacientes.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["id_Pacte"].Value = txtId.Text;
                        row.Cells["ApellidoyNombres"].Value = txtApelNombres.Text;
                        row.Cells["FechaNacim"].Value = dtpFechaNacim.Text;
                        row.Cells["Sexo"].Value = cboSexo.Text;
                        row.Cells["Tipo"].Value = cboTipoDoc.Text;
                        row.Cells["Numero"].Value = txtNumeroDoc.Text;
                        row.Cells["Domicilio"].Value = txtDomicilio.Text;
                        row.Cells["CodPostal"].Value = txtCodPos.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["Email"].Value = txtEmail.Text;
                        row.Cells["ObraSocial"].Value = cboObraSocial.Text;
                        row.Cells["PlanOS"].Value = cboPlanOS.Text;
                        row.Cells["Obs"].Value = txtObs.Text;
                        row.Cells["UserRegistro"].Value = txtUserRegistro.Text;
                        row.Cells["FechaRegistro"].Value = txtFechaRegistro.Text;
                        row.Cells["Afiliado"].Value = txtAfiliado.Text;

                        CambiarMail();
                        Limpiar();
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

        //***** ELIMINO UN PACIENTE *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            if (Convert.ToInt32(txtId.Text) != 0)
            {
                mensaje += "DESEA ELIMINAR ESTE PACIENTE...???";
                frmMsgBox msg = new frmMsgBox(mensaje, "question", 2);
                DialogResult dr = msg.ShowDialog();
                respuesta = dr.ToString();

                if (respuesta == "OK")
                {
                    CE_Pacientes cEPacientes = new CE_Pacientes()
                    {
                        id_Pacte = Convert.ToInt32(txtId.Text),
                    };

                    bool resultado = new CN_Pacientes().Eliminar(cEPacientes, out mensaje);

                    if (resultado)
                    {
                        dgvPacientes.Rows.RemoveAt(Convert.ToInt32(txtIndice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
            }
        }

        //***** VALIDO SI SON SOLO NÚMEROS *****
        private void txtNumeroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(validar.Validar(e.KeyChar));
        }

        //***** CARGO EL COMBO DE LAS ARROBAS *****
        private void CargarArrobas()
        {
            cboArrobas.Items.Clear();
            cboArrobas.Text = string.Empty;

            List<CE_Arrobas> ListaArrobas = new CN_Arrobas().ListaArrobas();

            foreach (CE_Arrobas item in ListaArrobas)
            {
                cboArrobas.Items.Add(item.Detalle);
                cboArrobas.SelectedIndex = -1;
            }
        }

        //***** AGREGO LA ARROBA AL MAILS *****
        private void cboExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.Trim() + cboArrobas.Text;
        }

        //***** PROCEDIMIENTO PARA REGRABAR EMAIL EN AGENDAS *****
        private void CambiarMail()
        {
            var okcab = new CN_CabeceraEco().ActualizoMail(id, mail);
        }


    }
}
