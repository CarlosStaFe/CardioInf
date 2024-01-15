using System;

namespace CapaEntidad
{
    public class CE_CodigosNacionales
    {
        public int id_Cod { get; set; }
        public int Codigo { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
