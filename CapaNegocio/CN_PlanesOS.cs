using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_PlanesOS
    {
        CD_PlanesOS cD_PlanesOS = new CD_PlanesOS();

        //***** LLAMO AL METODO PARA LISTAR LOS PLANES DE OBRAS SOCIALES *****
        public List<CE_PlanesOS> ListaPlanes()
        {
            return cD_PlanesOS.ListaPlanes();
        }

        //***** REGISTRA UN NUEVO PLAN *****
        public int Registrar(CE_PlanesOS obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.OSPlan == "")
            {
                mensaje += "* Debe ingresar una Obra Social. * ";
            }

            if (obj.NombrePlan == "")
            {
                mensaje += "Debe ingresar un Plan. * ";
            }

            if (obj.Estado == "")
            {
                mensaje += "Debe ingresar una Estado. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_PlanesOS.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA OBRA SOCIAL *****
        public bool Editar(CE_PlanesOS obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.OSPlan == "")
            {
                mensaje += "* Debe ingresar una Obra Social. * ";
            }

            if (obj.NombrePlan == "")
            {
                mensaje += "Debe ingresar un Plan. * ";
            }

            if (obj.Estado == "")
            {
                mensaje += "Debe ingresar una Estado. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_PlanesOS.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA LISTAR LOS PLANES DE UNA OBRA SOCIAL *****
        public List<CE_PlanesOS> ListaPlan(string nombreOS, out string mensaje)
        {
            return cD_PlanesOS.ListaPlan(nombreOS, out mensaje);
        }


    }
}
