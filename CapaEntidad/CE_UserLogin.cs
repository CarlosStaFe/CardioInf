using System;

namespace CapaEntidad
{
    public static class CE_UserLogin
    {
        public static int id_Usuario { get; set; }
        public static string Apellido { get; set; }
        public static string Nombres { get; set; }
        public static int Nivel { get; set; }
        public static string Funcion { get; set; }
        public static string Usuario { get; set; }
        public static string Clave { get; set; }
        public static bool Activo { get; set; }
        public static string UserRegistro { get; set; }
        public static DateTime FechaRegistro { get; set; }     // era string
    }
}
