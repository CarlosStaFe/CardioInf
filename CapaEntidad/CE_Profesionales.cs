using System;

namespace CapaEntidad
{
    public class CE_Profesionales
    {
        public int id_Prof { get; set; }
        public int Matricula { get; set; }
        public string ApelNombres { get; set; }
        public string Usuario { get; set; }
        public string TipoDoc { get; set; }
        public int NumeroDoc { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEstado { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
