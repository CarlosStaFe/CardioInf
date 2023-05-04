using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class xPasarDatos : Form
    {
        CN_CodigosPostales cN_CodigosPostales = new CN_CodigosPostales();
        CN_Localidades cN_Localidades = new CN_Localidades();
        CN_Departamentos cN_Departamentos = new CN_Departamentos();
        CN_Provincias cN_Provincias = new CN_Provincias();
        CN_CodigosNacionales cN_CodigosNacionales = new CN_CodigosNacionales();

        string respuesta;
        string localidad, departamento, provincia;
        int local, idCod, codigo, fklocal, fkdepto, fkprov;


        public xPasarDatos()
        {
            InitializeComponent();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            List<CE_CodigosNacionales> ListaCodPosNac = new CN_CodigosNacionales().ListaCodPosNac();

            foreach (CE_CodigosNacionales item in ListaCodPosNac)
            {
                dgvCodigosPostales.Rows.Add(new object[] { item.id_Cod, item.Codigo, item.Localidad, item.Departamento, item.Provincia });

                dgvCodigosPostales.Refresh();

                LeerDGV();
                BuscoDatos();

            }

        }

        private void LeerDGV()
        {
            int fila = dgvCodigosPostales.RowCount - 1;
            idCod = Convert.ToInt32(dgvCodigosPostales.Rows[fila].Cells[0].Value.ToString());
            codigo = Convert.ToInt32(dgvCodigosPostales.Rows[fila].Cells[1].Value.ToString());
            localidad = dgvCodigosPostales.Rows[fila].Cells[2].Value.ToString();
            departamento = dgvCodigosPostales.Rows[fila].Cells[3].Value.ToString();
            provincia = dgvCodigosPostales.Rows[fila].Cells[4].Value.ToString();
        }

        private void BuscoDatos()
        {
            List<CE_CodigosPostales> ListaCodigos = new CN_CodigosPostales().ListaCodigos(codigo);

            foreach (CE_CodigosPostales item in ListaCodigos)
            {
                fklocal = item.fk_Local;
                fkdepto = item.fk_Depto;
                fkprov = item.fk_Prov;
                codigo = item.CodigoPostal;
                localidad = item.Localidad;
                departamento = item.Departamento;
                provincia = item.Provincia;

                BuscoLocalidad();


            }

        }

        private void BuscoLocalidad()
        {

        }





    }
}
