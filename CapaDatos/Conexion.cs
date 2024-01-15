using System;
using System.IO;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public abstract class Conexion
    {
        string buscar, conexion;

        //static string nombre_servidor = Dns.GetHostName();
        private readonly string connectionString;

        public Conexion()
        {
            buscar = "Conexion";
            conexion = Proceso(buscar);

            connectionString = conexion;
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        //***** PROCESO PARA BUSCAR LOS DATOS EN config.txt *****
        public string Proceso(string buscar)
        {
            string path = Directory.GetCurrentDirectory();

            string linea = string.Empty;
            string texto = buscar;
            string renglon = string.Empty;

            try
            {
                StreamReader sr = new StreamReader(path + "\\config.txt");

                while ((linea = sr.ReadLine()) != null)
                {
                    renglon = linea;
                    int pos1 = linea.IndexOf("=");
                    linea = linea.Substring(0, pos1);

                    if (linea == texto)
                    {
                        linea = renglon.Substring(pos1 + 1);
                        return linea;
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                linea = "Exception: " + e.Message;
            }
            finally
            {
            }
            return linea;
        }

    }

}
//connectionString = "Data Source=SERVIDOR\\DATASERVER;Initial Catalog=DBColegMart;Persist Security Info=True;User ID=Admin;Password=administrador";
//connectionString = "Data Source=" + servidor + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + usuario + ";Password=" + password + " ";

