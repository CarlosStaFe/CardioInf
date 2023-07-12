using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Agendas
    {
        CD_Agendas cD_Agendas = new CD_Agendas();

        //***** LLAMO AL METODO PARA LISTAR LAS AGENDAS *****
        public List<CE_Agendas> ListaAgendas()
        {
            return cD_Agendas.ListaAgendas();
        }

        //***** REGISTRA UNA NUEVA AGENDA *****
        public int Registrar(CE_Agendas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Profesional == "")
            {
                mensaje += "* Debe ingresar un Profesional. * ";
            }

            if (obj.Tipo == "")
            {
                mensaje += "Debe ingresar un Tipo de Consulta. * ";
            }

            if (obj.Pacte == 0)
            {
                mensaje += "Debe ingresar un Paciente. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Agendas.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA AGENDA *****
        public bool Editar(CE_Agendas obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Profesional == "")
            {
                mensaje += "* Debe ingresar un Profesional. * ";
            }

            if (obj.Tipo == "")
            {
                mensaje += "Debe ingresar un Tipo de Consulta. * ";
            }

            if (obj.Pacte == 0)
            {
                mensaje += "Debe ingresar un Paciente. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Agendas.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA AGENDA *****
        public bool Eliminar(CE_Agendas obj, out string mensaje)
        {
            return cD_Agendas.Eliminar(obj, out mensaje);
        }


    }
}
