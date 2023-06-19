using System;

namespace CapaEntidad
{
    //***** PARA LA ACTUALIZACION DE PERMISOS *****
    public class CE_Permisos
    {
        public int id_Permiso { get; set; }
        public int fk_Usuarios { get; set; }
        public int fk_Botones { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
    }

    //***** PARA CARGAR EL DGV *****
    public class CE_PermisosNew
    {
        public int id_Permiso { get; set; }
        public int fk_Usuarios { get; set; }
        public int fk_Botones { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
