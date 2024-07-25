using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utiles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class frmHistorias : Form
    {
        string fechistoria;
        int id;

        public frmHistorias(int idPcte)
        {
            InitializeComponent();
            id = Convert.ToInt32(idPcte);
            txtidPcte.Text = Convert.ToString(idPcte);
        }

        private void frmHistorias_Load(object sender, EventArgs e)
        {
            txtUserRegistro.Text = CE_UserLogin.Usuario;
            fechistoria = new ProcesarFecha().Procesar(dtpFecha.Text);
            btnSearch.Visible = false;
            CargarCombos();
        }

        //***** CARGO EL COMBO DE LOS PROFESIONALES *****
        private void CargarCombos()
        {
            cboProfesionales.Items.Clear();
            cboProfesionales.Text = string.Empty;

            List<CE_Profesionales> ListaProf = new CN_Profesionales().ListaProf();

            foreach (CE_Profesionales item in ListaProf)
            {
                cboProfesionales.Items.Add(item.Usuario);
                cboProfesionales.SelectedIndex = -1;
            }

            cboProfesionales.Text = txtUserRegistro.Text;

            if (id > 0)
            {
                btnSearch.Visible = true;
                List<CE_Pacientes> BuscaPacte = new CN_Pacientes().BuscarPacte(Convert.ToString(id));

                foreach (CE_Pacientes item in BuscaPacte)
                {
                    lblPaciente.Text = item.ApelNombres + " - " + item.FechaNacim + " - " + item.Sexo + " - " + item.TipoDoc + " - " + item.NumeroDoc;
                    lblObraSocial.Text = item.ObraSocial;
                    lblPlan.Text = item.PlanOS;
                    lblAfiliado.Text = item.Afiliado;

                    txtNumeroDoc.Text = Convert.ToString(item.NumeroDoc);
                    txtApelNombres.Text = item.ApelNombres;
                }

                CargarHistoria();
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
            btnSearch.Visible = false;
            dgvHistoria.Rows.Clear();
            txtId.Text = "0";
            txtIndice.Text = "0";
            txtidPcte.Text = string.Empty;
            lblPaciente.Text = string.Empty;
            cboProfesionales.Text = string.Empty;
            btnEliminar.Visible = false;

            btnBuscaPacte.Select();
        }

        //***** PROCEDIMIENTO DEL BOTON DE BÚSQUEDA DE PACIENTE *****
        private void btnBuscaPacte_Click(object sender, EventArgs e)
        {
            mdlPacientes BuscaPacte = new mdlPacientes("btnHistoria");
            AddOwnedForm(BuscaPacte);
            BuscaPacte.ShowDialog();

            btnSearch.Visible = true;
            id = Convert.ToInt32(txtidPcte.Text);
            CargarHistoria();
        }

        //***** PROCEDIMIENTO PARA BUSCAR SI TIENE HISTORIA CLÍNICA *****
        private void CargarHistoria()
        {
            dgvHistoria.Rows.Clear();

            List<CE_Historias> ListaHis = new CN_Historias().ListaHistorias(id);

            //***** CARGO EL DGV *****
            foreach (CE_Historias item in ListaHis)
            {
                dgvHistoria.Rows.Add(new object[] { "", item.id_His, item.idPcte, item.NroDoc, item.NombreCompleto, item.Fecha, item.Medico, item.Comentario, item.Obs,
                                                    item.UserRegistro, item.FechaRegistro });
            }

            //***** CARGO EL COMBO DE BUSQUEDA *****
            foreach (DataGridViewColumn columna in dgvHistoria.Columns)
            {
                if (columna.Visible == true && columna.Name != "Seleccionar")
                {
                    cboBusqueda.Items.Add(columna.HeaderText);
                }
            }
        }

        //***** PROCEDIMIENTO PARA BUSCAR HISTORIAS VIEJAS *****
        private void btnSearch_Click(object sender, EventArgs e)
        {
            mdlHistoriasOld HistoriaOld = new mdlHistoriasOld("btnHistoriaOld", txtidPcte.Text, txtApelNombres.Text, txtNumeroDoc.Text);
            AddOwnedForm(HistoriaOld);
            HistoriaOld.ShowDialog();

            id = Convert.ToInt32(txtidPcte.Text);
            CargarHistoria();

        }

        //***** COLOCO EL ÍCONO EN CADA RENGLÓN DEL DGV *****
        private void dgvHistoria_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
        private void dgvHistoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHistoria.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvHistoria.Rows[indice].Cells["id_Histo"].Value.ToString();
                    txtidPcte.Text = dgvHistoria.Rows[indice].Cells["idPcte"].Value.ToString();
                    txtComentario.Text = dgvHistoria.Rows[indice].Cells["Detalle"].Value.ToString();
                    cboProfesionales.Text = dgvHistoria.Rows[indice].Cells["Medico"].Value.ToString();
                    txtPediatra.Text = dgvHistoria.Rows[indice].Cells["Obs"].Value.ToString();
                    dtpFecha.Value = Convert.ToDateTime(dgvHistoria.Rows[indice].Cells["Fecha"].Value.ToString());
                    txtUserRegistro.Text = dgvHistoria.Rows[indice].Cells["UserRegistro"].Value.ToString();
                    txtFechaRegistro.Text = dgvHistoria.Rows[indice].Cells["FechaRegistro"].Value.ToString();

                    btnEliminar.Visible = true;
                }
            }
        }

        //***** MUEVO LO INGRESADO A LA HISTORIA *****
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            CE_Historias cE_Historias = new CE_Historias()
            {
                idPcte = Convert.ToInt32(txtidPcte.Text),
                NroDoc = Convert.ToInt32(txtNumeroDoc.Text),
                NombreCompleto = txtApelNombres.Text,
                Medico = cboProfesionales.Text,
                Fecha = Convert.ToDateTime(dtpFecha.Value),
                Comentario = txtComentario.Text,
                Obs = txtPediatra.Text,
                UserRegistro = CE_UserLogin.Usuario,
                FechaRegistro = DateTime.Today
            };

            int idHisto = new CN_Historias().Registrar(cE_Historias, out mensaje);

            CargarHistoria();
        }

        //***** PROCEDIMIENTO PARA ELIMINAR LA HISTORIA *****
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            CE_Historias cEHistorias = new CE_Historias()
            {
                id_His = Convert.ToInt32(txtId.Text),
            };

            bool resultado = new CN_Historias().Eliminar(cEHistorias, out mensaje);

            CargarHistoria();
        }
    }
}
