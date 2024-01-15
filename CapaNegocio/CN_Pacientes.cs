using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Pacientes
    {
        CD_Pacientes cD_Pacientes = new CD_Pacientes();

        //***** LLAMO AL METODO PARA LISTAR LOS PACIENTES *****
        public List<CE_Pacientes> ListaPacte(string texto)
        {
            return cD_Pacientes.ListaPacte(texto);
        }

        //***** REGISTRA UN NUEVO PACIENTE *****
        public int Registrar(CE_Pacientes obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.ApelNombres == "")
            {
                mensaje += "* Debe ingresar un Apellido y Nombres. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Pacientes.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN PACIENTE *****
        public bool Editar(CE_Pacientes obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.ApelNombres == "")
            {
                mensaje += "* Debe ingresar un Apellido y Nombres. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Pacientes.Editar(obj, out mensaje);
            }
        }

        //***** BUSQUEDA DEL PACIENTE DE LA ECOGRAFÍA *****
        public List<CE_Pacientes> BuscarPacte(string pacte)
        {
            return cD_Pacientes.BuscarPacte(pacte);
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN PACIENTE *****
        public bool Eliminar(CE_Pacientes obj, out string mensaje)
        {
            return cD_Pacientes.Eliminar(obj, out mensaje);
        }

    }
}
