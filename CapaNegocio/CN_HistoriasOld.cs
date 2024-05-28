using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_HistoriasOld
    {
        CD_HistoriasOld cD_HistoriasOld = new CD_HistoriasOld();

        //***** LLAMO AL METODO PARA LISTAR LAS HISTORIAS VIEJAS *****
        public List<CE_HistoriasOld> ListaHistorias()
        {
            return cD_HistoriasOld.ListaHistorias();
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA HISTORIA VIEJA *****
        public bool Eliminar(CE_HistoriasOld obj, out string mensaje)
        {
            return cD_HistoriasOld.Eliminar(obj, out mensaje);
        }

    }
}
