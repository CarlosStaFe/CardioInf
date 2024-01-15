using System;

namespace CapaEntidad
{
    public class CE_Comprobantes
    {
        public int id_Cpbte { get; set; }
        public string Tipo { get; set; }
        public int Numero { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
