using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Planificacion
    {
        CD_Planificacion cD_Planificacion = new CD_Planificacion();

        //***** LLAMO AL METODO PARA LISTAR LA PLANIFICACION *****
        public List<CE_Planificacion> ListaPlan(string fechaplan)
        {
            return cD_Planificacion.ListaPlan(fechaplan);
        }

        //***** REGISTRA UNA NUEVA PLANIFICACION *****
        public int Registrar(CE_Planificacion obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Medico == "")
            {
                mensaje += "* Debe ingresar un Profesional. * ";
            }

            if (obj.Tipo == "")
            {
                mensaje += "Debe ingresar un Tipo de Consulta. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_Planificacion.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA PLANIFICACION *****
        public bool Editar(CE_Planificacion obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Medico == "")
            {
                mensaje += "* Debe ingresar un Profesional. * ";
            }

            if (obj.Tipo == "")
            {
                mensaje += "Debe ingresar un Tipo de Consulta. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_Planificacion.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA PLANIFICACION *****
        public bool Eliminar(CE_Planificacion obj, out string mensaje)
        {
            return cD_Planificacion.Eliminar(obj, out mensaje);
        }

        //***** BUSQUEDA DE LA PLANIFICACION *****
        public List<CE_Planificacion> BuscarPlan(string idPlan)
        {
            return cD_Planificacion.BuscarPlan(idPlan);
        }

        //***** LEER LA PLANIFICACION PARA LA FECHA *****
        public List<CE_Planificacion> LeePlan(string fecha)
        {
            return cD_Planificacion.LeePlan(fecha);
        }

    }
}
