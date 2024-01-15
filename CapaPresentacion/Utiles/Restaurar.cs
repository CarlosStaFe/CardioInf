using System;
using System.Net;
using MySql.Data.MySqlClient;

namespace CapaPresentacion.Utiles
{
    public class Restaurar
    {
        public bool RealizarRestore(string nombre)
        {
            string mensaje;
            string nombre_servidor = Dns.GetHostName();
            string buscar = "Conexion";
            string conex = new LeerConfig().Proceso(buscar);
            buscar = "PathBackup";
            string backup = new LeerConfig().Proceso(buscar);
            backup += nombre;

            try
            {
                MySqlConnection conexion = new MySqlConnection(conex);
                MySqlCommand cmdo = new MySqlCommand();
                MySqlBackup respaldo = new MySqlBackup(cmdo);

                cmdo.Connection = conexion;
                conexion.Open();

                respaldo.ImportFromFile(backup);

                conexion.Close();
                conexion.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                mensaje = "error siguiente " + ex.Message;
                return false;
            }
            finally
            {
            }
        }
    }
}
