using System;

namespace CapaEntidad
{
    public class CE_Localidades
    {
        public int id_Local { get; set; }
        public int fk_Depto { get; set; }
        public int fk_Prov { get; set; }
        public string Localidad { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
