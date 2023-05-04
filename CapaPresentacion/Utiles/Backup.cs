using System;
using System.Data.SqlClient;
using System.Net;

namespace CapaPresentacion.Utiles
{
    public class Backup
    {
        public bool RealizarCopia()
        {
            string nombre_servidor = Dns.GetHostName();

            SqlConnection conexion = new SqlConnection("Data Source=" + nombre_servidor + "\\DATASERVER;Initial Catalog=DBCardioInf;Persist Security Info=True;User ID=sa;Password=soporte");

            string nombre = (DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")) + "_" + "DBCardioInf.bak";

            try
            {
                conexion.Open();

                string comando = "BACKUP DATABASE [DBCardioInf] TO  DISK = N'E:\\DBCardioInf\\Backup\\" + nombre + "' WITH NOFORMAT, NOINIT,  NAME = N'DBCardioInf-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                SqlCommand cmd = new SqlCommand(comando, conexion);

                cmd.ExecuteNonQuery();
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
