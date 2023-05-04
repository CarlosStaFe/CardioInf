using System;
using System.Data.SqlClient;
using System.Net;

namespace CapaPresentacion.Utiles
{
    public class Restaurar
    {
        public bool RealizarRestore(string nombre)
        {
            string nombre_servidor = Dns.GetHostName();

            SqlConnection conexion = new SqlConnection("Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBCardioInf;Persist Security Info=True;User ID=sa;Password=soporte");

            try
            {
                conexion.Open();

                string str1 = string.Format("ALTER DATABASE[DBCardioInf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(str1, conexion);
                cmd1.ExecuteNonQuery();

                string str2 = "USE MASTER RESTORE DATABASE[DBCardioInf] FROM DISK = N'E:\\DBCardioInf\\Backup\\" + nombre + "' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(str2, conexion);
                cmd2.ExecuteNonQuery();

                string str3 = string.Format("ALTER DATABASE[DBCardioInf] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(str3, conexion);
                cmd3.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }
    }
}
