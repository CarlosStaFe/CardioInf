using System;

namespace CapaEntidad
{
    public class CE_Planificacion
    {
        public int id_Plan { get; set; }
        public DateTime Fecha { get; set; }
        public string Medico { get; set; }
        public string Tipo { get; set; }
        public string DesdeHr { get; set; }
        public string DesdeMin { get; set; }
        public string HastaHr { get; set; }
        public string HastaMin { get; set; }
        public string Rango { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
