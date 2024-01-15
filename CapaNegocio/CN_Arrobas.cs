using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Arrobas
    {
        CD_Arrobas cD_Arrobas = new CD_Arrobas();

        //***** LLAMO AL METODO PARA LISTAR LAS ARROBAS *****
        public List<CE_Arrobas> ListaArrobas()
        {
            return cD_Arrobas.ListaArrobas();
        }

        //***** REGISTRA UNA NUEVA ARROBA *****
        public int Registrar(CE_Arrobas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Detalle == "")
            {
                mensaje += "Debe ingresar un Detalle. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Arrobas.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA ARROBA *****
        public bool Editar(CE_Arrobas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Detalle == "")
            {
                mensaje += "* Debe ingresar un Detalle. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Arrobas.Editar(obj, out mensaje);
            }
        }
    }
}
