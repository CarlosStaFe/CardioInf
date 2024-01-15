using System;

namespace CapaEntidad
{
    public class CE_Pacientes
    {
        public int id_Pacte { get; set; }
        public string ApelNombres { get; set; }
        public DateTime FechaNacim { get; set; }
        public string Sexo { get; set; }
        public string TipoDoc { get; set; }
        public int NumeroDoc { get; set; }
        public string Domicilio { get; set; }
        public int CodPostal { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string ObraSocial { get; set; }
        public string PlanOS { get; set; }
        public string Afiliado { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
