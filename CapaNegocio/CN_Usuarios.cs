using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        CD_Usuarios cD_Usuarios = new CD_Usuarios();

        //***** BUSQUEDA DEL USUARIO EN EL LOGIN *****
        public bool LoginUser(string user, string pass)
        {
            return cD_Usuarios.Login(user, pass);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS USUARIOS *****
        public List<CE_Usuarios> ListaUser()
        {
            return cD_Usuarios.ListaUser();
        }

        //***** REGISTRA UN NUEVO USUARIO *****
        public int Registrar(CE_Usuarios obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Apellido == "")
            {
                mensaje += "* Debe ingresar un Apellido. * ";
            }

            if (obj.Nombres == "")
            {
                mensaje += "Debe ingresar un Nombre. * ";
            }

            if (obj.Funcion == "")
            {
                mensaje += "Debe ingresar una Función. * ";
            }

            if (obj.Usuario == "")
            {
                mensaje += "Debe ingresar un Usuario. * ";
            }

            if (obj.Clave == "")
            {
                mensaje += "Debe ingresar una Clave. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Usuarios.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN USUARIO *****
        public bool Editar(CE_Usuarios obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Apellido == "")
            {
                mensaje += "* Debe ingresar un Apellido. * ";
            }

            if (obj.Nombres == "")
            {
                mensaje += "Debe ingresar un Nombre. * ";
            }

            if (obj.Funcion == "")
            {
                mensaje += "Debe ingresar una Función. * ";
            }

            if (obj.Usuario == "")
            {
                mensaje += "Debe ingresar un Usuario. * ";
            }

            if (obj.Clave == "")
            {
                mensaje += "Debe ingresar una Clave. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Usuarios.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN USUARIO *****
        public bool Eliminar(CE_Usuarios obj, out string mensaje)
        {
            return cD_Usuarios.Eliminar(obj, out mensaje);
        }
    }
}
