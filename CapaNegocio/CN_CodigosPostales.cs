using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CodigosPostales
    {
        CD_CodigosPostales cD_CodigosPostales = new CD_CodigosPostales();

        //***** LLAMO AL METODO PARA LISTAR LOS CÓDIGOS POSTALES *****
        public List<CE_CodigosPostales> ListaCodPos()
        {
            return cD_CodigosPostales.ListaCodPos();
        }

        //***** LLAMO AL METODO PARA REGISTRAR UN CODIGO POSTAL *****
        public int Registrar(CE_CodigosPostales obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Localidad == "")
            {
                mensaje += "* Debe ingresar un Código Postal. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_CodigosPostales.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN CODIGO POSTAL *****
        public bool Editar(CE_CodigosPostales obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Localidad == "")
            {
                mensaje += "* Debe ingresar un Código Postal. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_CodigosPostales.Editar(obj, out mensaje);
            }
        }

        //***** BUSQUEDA DE LOS CÓDIGOS POSTALES DEL COLEGIADO *****
        public string BuscaCodPos(int local)
        {
            return cD_CodigosPostales.BuscaCodPos(local);
        }

    }
}
