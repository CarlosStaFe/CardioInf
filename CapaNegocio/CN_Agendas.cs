using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Agendas
    {
        CD_Agendas cD_Agendas = new CD_Agendas();

        //***** LLAMO AL METODO PARA LISTAR LAS AGENDAS *****
        public List<CE_Agendas> ListaAgendas(string fecha)
        {
            return cD_Agendas.ListaAgendas(fecha);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS AGENDASDE UN PROFESIONAL *****
        public List<CE_Agendas> AgendaCorta(string prof, string fecha)
        {
            return cD_Agendas.AgendaCorta(prof,fecha);
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

            if (obj.Hora == 0)
            {
                mensaje += "Debe ingresar una Hora. * ";
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

            if (obj.Hora == 0)
            {
                mensaje += "Debe ingresar una Hora. * ";
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

        //***** LLAMO AL METODO PARA CANBIAR EL ESTADO Y NUMERO *****
        public bool ActualizoAgenda(int id, string estado, int numero)
        {
            return cD_Agendas.ActualizoAgenda(id, estado, numero);
        }

        //***** LLAMO AL METODO PARA CANBIAR EL ESTADO *****
        public bool ActualizoEstado(int id, string estado)
        {
            return cD_Agendas.ActualizoEstado(id, estado);
        }


    }
}
