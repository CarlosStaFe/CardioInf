using System;

namespace CapaEntidad
{
    public class CE_Historias
    {
        public int id_His { get; set; }
        public int idPcte { get; set; }
        public int NroDoc { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Fecha { get; set; }
        public string Medico { get; set; }
        public string Comentario { get; set; }
        public string Obs { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
