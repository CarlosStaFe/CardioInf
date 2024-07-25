using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CabeceraEco
    {
        CD_CabeceraEco cD_CabeceraEco = new CD_CabeceraEco();

        //***** LLAMO AL METODO PARA LISTAR LAS CABECERAS DE LAS ECOGRAFÍAS *****
        public List<CE_CabeceraEco> ListaCabEco(string fecha)
        {
            return cD_CabeceraEco.ListaCabEco(fecha);
        }

        //***** REGISTRA UNA NUEVA CABECERA DE ECOGRAFÍA *****
        public int Registrar(CE_CabeceraEco obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return cD_CabeceraEco.Registrar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA EDITAR UNA CABECERA DE ECOGRAFÍA *****
        public bool Editar(CE_CabeceraEco obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return cD_CabeceraEco.Editar(obj, out mensaje);
            }
        }

        //***** LLAMO AL METODO PARA ELIMINAR UNA CABECERA DE ECOGRAFÍA *****
        public bool Eliminar(CE_CabeceraEco obj, out string mensaje)
        {
            return cD_CabeceraEco.Eliminar(obj, out mensaje);
        }

        //***** LLAMO AL METODO PARA LISTAR LAS CABECERAS DE ECOGRAFIAS PARA CONSULTA *****
        public List<CE_CabeceraEco> ListaEco()
        {
            return cD_CabeceraEco.ListaEco();
        }

        //***** LLAMO AL METODO PARA CANBIAR EL ESTADO *****
        public bool ActualizoCabecera(int id, string estado)
        {
            return cD_CabeceraEco.ActualizoCabecera(id, estado);
        }

        //***** LLAMO AL METODO PARA LEER LA CABECERA *****
        public List<CE_CabeceraEco> LeerCabecera(string id, string numero)
        {
            return cD_CabeceraEco.LeerCabecera(id, numero);
        }

        //***** LLAMO AL METODO PARA MODIFICAR EL MAIL DE LAS CABECERAS *****
        public bool ActualizoMail(int id, string mail)
        {
            return cD_CabeceraEco.ActualizoMail(id, mail);
        }

    }
}
