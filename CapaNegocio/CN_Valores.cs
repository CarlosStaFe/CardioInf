using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Valores
    {
        CD_Valores cD_Valores = new CD_Valores();

        //***** LLAMO AL METODO PARA LISTAR LOS VALORES DE LOS ESTUDIOS *****
        public List<CE_Valores> ListaValores()
        {
            return cD_Valores.ListaValores();
        }

        //***** REGISTRA UN NUEVO VALOR *****
        public int Registrar(CE_Valores obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Estudio == "")
            {
                mensaje += "* Debe ingresar un Estudio. * ";
            }

            if (obj.Valor == "")
            {
                mensaje += "Debe ingresar un Valor. * ";
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
                return cD_Valores.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN VALOR *****
        public bool Editar(CE_Valores obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (obj.Estudio == "")
            {
                mensaje += "* Debe ingresar un Estudio. * ";
            }

            if (obj.Valor == "")
            {
                mensaje += "Debe ingresar un Valor. * ";
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
                return cD_Valores.Editar(obj, out mensaje);
            }
        }

    }
}
