using System;

namespace CapaEntidad
{
    public class CE_Usuarios
    {
        public int id_Usuario { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public int Nivel { get; set; }
        public string Funcion { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
