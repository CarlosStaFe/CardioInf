using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_DetalleEco
    {
        CD_DetalleEco cD_DetalleEco = new CD_DetalleEco();

        //***** LLAMO AL METODO PARA LISTAR LOS DETALLES DE LAS ECOGRAFIAS *****
        public List<CE_DetalleEco> ListaDetEco()
        {
            return cD_DetalleEco.ListaDetEco();
        }

        //***** REGISTRA UN DETALLE DE LA ECOGRAFÍA *****
        public int Registrar(CE_DetalleEco obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_DetalleEco.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UN DETALLE DE ECOGRAFÍA *****
        public bool Editar(CE_DetalleEco obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_DetalleEco.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UN DETALLE DE ECOGRAFÍA *****
        public bool Eliminar(CE_DetalleEco obj, out string mensaje)
        {
            return cD_DetalleEco.Eliminar(obj, out mensaje);
        }

        //***** LLAMO AL METODO PARA LISTAR LOS DETALLES DE ECOGRAFIAS PARA CONSULTA *****
        public List<CE_DetalleEco> ListaEco()
        {
            return cD_DetalleEco.ListaEco();
        }

        //***** LLAMO AL METODO PARA LEER EL DETALLE DE LA ECOGRAFÍA *****
        public List<CE_DetalleEco> LeerDetalle(string numero)
        {
            return cD_DetalleEco.LeerDetalle(numero);
        }

    }
}
