using CapaDatos;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class CN_CodigosNacionales
    {
        CD_CodigosNacionales cD_CodigosNacionales = new CD_CodigosNacionales();

        //***** LLAMO AL METODO PARA LISTAR LOS CÓDIGOS POSTALES  NACIONALES *****
        public List<CE_CodigosNacionales> ListaCodPosNac()
        {
            return cD_CodigosNacionales.ListaCodPosNac();
        }

    }
}
