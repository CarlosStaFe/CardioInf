using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Localidades
    {
        CD_Localidades cD_Localidades = new CD_Localidades();

        //***** LLAMO AL METODO PARA LISTAR LAS LOCALIDADES *****
        public List<CE_Localidades> ListaLocal()
        {
            return cD_Localidades.ListaLocal();
        }

        //***** LLAMO AL METODO PARA REGISTRAR UNA LOCALIDAD *****
        public int Registrar(CE_Localidades obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Localidad == "")
            {
                mensaje += "* Debe ingresar una Localidad. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Localidades.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN BOTÓN *****
        public bool Editar(CE_Localidades obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Localidad == "")
            {
                mensaje += "* Debe ingresar una Localidad. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Localidades.Editar(obj, out mensaje);
            }
        }

    }
}
