using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Ecografias
    {
        CD_Ecografias cD_Ecografias = new CD_Ecografias();

        //***** LLAMO AL METODO PARA LISTAR LAS ECOGRAFIAS *****
        public List<CE_Ecografias> ListaEcografias()
        {
            return cD_Ecografias.ListaEcografias();
        }

        //***** REGISTRA UNA NUEVA ECOGRAFÍA *****
        public int Registrar(CE_Ecografias obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Ecografias.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA ECOGRAFÍA *****
        public bool Editar(CE_Ecografias obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Ecografias.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA ECOGRAFÍA *****
        public bool Eliminar(CE_Ecografias obj, out string mensaje)
        {
            return cD_Ecografias.Eliminar(obj, out mensaje);
        }

    }
}
