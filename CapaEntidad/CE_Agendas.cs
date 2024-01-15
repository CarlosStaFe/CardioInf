using System;

namespace CapaEntidad
{
    public class CE_Agendas
    {
        public int id_Agda { get; set; }
        public DateTime Fecha { get; set; }
        public string Profesional { get; set; }
        public int Turno { get; set; }
        public string Tipo { get; set; }
        public int Pacte { get; set; }
        public string Detalle { get; set; }
        public int NumeroEco { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEstado { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
