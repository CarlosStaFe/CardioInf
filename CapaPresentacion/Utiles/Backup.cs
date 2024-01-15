using System;
using System.Net;
using MySql.Data.MySqlClient;

namespace CapaPresentacion.Utiles
{
    public class Backup
    {
        public bool RealizarCopia()
        {
            string nombre_servidor = Dns.GetHostName();

            string buscar = "Conexion";
            string conex = new LeerConfig().Proceso(buscar);
            conex += ";charset=utf8;Convert Zero Datetime=true";
            buscar = "PathBackup";
            string backup = new LeerConfig().Proceso(buscar);

            string nombre = backup + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "_" + "DBCardioInf.sql";

            try
            {
                using(MySqlConnection conexion = new MySqlConnection(conex))
                {
                    using(MySqlCommand cmdo = new MySqlCommand())
                    {
                        using(MySqlBackup mb = new MySqlBackup(cmdo))
                        {
                            cmdo.Connection = conexion;
                            conexion.Open();
                            mb.ExportToFile(nombre);
                            conexion.Close();
                            conexion.Dispose();
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
            }
        }
    }
}
