using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Profesionales
    {
        CD_Profesionales cD_Profesionales = new CD_Profesionales();

        //***** LLAMO AL METODO PARA LISTAR LOS PROFESIONALES *****
        public List<CE_Profesionales> ListaProf()
        {
            return cD_Profesionales.ListaProf();
        }

        //***** REGISTRA UN NUEVO PROFESIONAL *****
        public int Registrar(CE_Profesionales obj, out string mensaje)
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
                return cD_Profesionales.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN PROFESIONAL *****
        public bool Editar(CE_Profesionales obj, out string mensaje)
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
                return cD_Profesionales.Editar(obj, out mensaje);
            }
        }

    }
}
