using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Historias
    {
        CD_Historias cD_Historias = new CD_Historias();

        //***** LLAMO AL METODO PARA LISTAR LAS HISTORIAS *****
        public List<CE_Historias> ListaHistorias(int idpcte)
        {
            return cD_Historias.ListaHistorias(idpcte);
        }

        //***** REGISTRA UNA NUEVA HISTORIA *****
        public int Registrar(CE_Historias obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Historias.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA HISTORIA *****
        public bool Eliminar(CE_Historias obj, out string mensaje)
        {
            return cD_Historias.Eliminar(obj, out mensaje);
        }

    }
}
