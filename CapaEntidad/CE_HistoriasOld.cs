using System;

namespace CapaEntidad
{
    public class CE_HistoriasOld
    {
        public int id_His { get; set; }
        public int idPaciente { get; set; }
        public int Documento { get; set; }
        public string ApelNombres { get; set; }
        public string Medico { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public string Adjunto { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
