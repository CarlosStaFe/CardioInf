using System;

namespace CapaEntidad
{
    public class CE_ObrasSociales
    {
        public int id_OS { get; set; }
        public string Nombre { get; set; }
        public string Cuit { get; set; }
        public string Domicilio { get; set; }
        public int CodPostal { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
