using System;

namespace CapaEntidad
{
    public class CE_CodigosPostales
    {
        public int id_CodPos { get; set; }
        public int CodigoPostal { get; set; }
        public int fk_Local { get; set; }
        public int fk_Depto { get; set; }
        public int fk_Prov { get; set; }
        public string Localidad { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
