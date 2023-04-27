using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Provincias
    {
        CD_Provincias cD_Provincias = new CD_Provincias();

        //***** LLAMO AL METODO PARA LISTAR LAS PROVINCIAS *****
        public List<CE_Provincias> ListaProvincias()
        {
            return cD_Provincias.ListaProvincias();
        }

        //***** LLAMO AL METODO PARA LISTAR LAS PROVINCIAS PARA UN COMBO *****
        public List<CE_Provincias> ListaProvincia()
        {
            return cD_Provincias.ListaProvincia();
        }

    }
}
