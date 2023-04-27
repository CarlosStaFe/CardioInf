using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_Departamentos
    {
        CD_Departamentos cD_Departamentos = new CD_Departamentos();

        //***** LLAMO AL METODO PARA LISTAR LOS DEPARTAMENTOS *****
        public List<CE_Departamentos> ListaDeptos()
        {
            return cD_Departamentos.ListaDeptos();
        }

        //***** LLAMO AL METODO PARA LISTAR LOS DEPARTAMENTOS PARA UN COMBO *****
        public List<CE_Departamentos> ListaDepto()
        {
            return cD_Departamentos.ListaDepto();
        }

    }
}
