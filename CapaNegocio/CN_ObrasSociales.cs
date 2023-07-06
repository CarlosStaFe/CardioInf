using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_ObrasSociales
    {
        CD_ObrasSociales cD_ObraSocial = new CD_ObrasSociales();

        //***** LLAMO AL METODO PARA LISTAR LAS OBRAS SOCIALES *****
        public List<CE_ObrasSociales> ListaOS()
        {
            return cD_ObraSocial.ListaOS();
        }

        //***** REGISTRA UNA NUEVA OBRA SOCIAL *****
        public int Registrar(CE_ObrasSociales obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                mensaje += "* Debe ingresar un Nombre. * ";
            }

            if (obj.Cuit == "")
            {
                mensaje += "Debe ingresar un C.U.I.T. * ";
            }

            if (obj.Domicilio == "")
            {
                mensaje += "Debe ingresar una domicilio. * ";
            }

            if (obj.CodPostal == 0)
            {
                mensaje += "Debe ingresar un Código Postal. * ";
            }

            if (obj.Telefono == "")
            {
                mensaje += "Debe ingresar un Teléfono. * ";
            }

            if (obj.Email == "")
            {
                mensaje += "Debe ingresar un Email. * ";
            }

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_ObraSocial.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA OBRA SOCIAL *****
        public bool Editar(CE_ObrasSociales obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Nombre == "")
            {
                mensaje += "* Debe ingresar un Nombre. * ";
            }

            if (obj.Cuit == "")
            {
                mensaje += "Debe ingresar un C.U.I.T. * ";
            }

            if (obj.Domicilio == "")
            {
                mensaje += "Debe ingresar una domicilio. * ";
            }

            if (obj.CodPostal == 0)
            {
                mensaje += "Debe ingresar un Código Postal. * ";
            }

            if (obj.Telefono == "")
            {
                mensaje += "Debe ingresar un Teléfono. * ";
            }

            if (obj.Email == "")
            {
                mensaje += "Debe ingresar un Email. * ";
            }

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_ObraSocial.Editar(obj, out mensaje);
            }
        }

    }

}

