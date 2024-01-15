using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Permisos
    {
        CD_Permisos cD_Permisos = new CD_Permisos();

        //***** BUSQUEDA DE LOS PERMISOS POR USUARIO *****
        public List<CE_Permisos> ListaPermisos(int idUsuario)
        {
            return cD_Permisos.ListaPermisos(idUsuario);
        }
    }

    public class CN_PermisosNew
    {
        CD_PermisosNew cD_PermisosNew = new CD_PermisosNew();

        //***** REGISTRA UN NUEVO PERMISO *****
        public int Registrar(CE_PermisosNew obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_PermisosNew.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN PERMISO *****
        public bool Eliminar(CE_PermisosNew obj, out string mensaje)
        {
            return cD_PermisosNew.Eliminar(obj, out mensaje);
        }
    }
}
