using System;
using System.IO;

namespace CapaPresentacion.Utiles
{
    public class LeerConfig
    {
        [STAThread]
        public string Proceso(string buscar)
        {
            string linea = string.Empty;
            string texto = buscar;
            string renglon = string.Empty;

            try
            {
                //StreamReader sr = new StreamReader("E:\\DBColegMart\\config.txt");
                StreamReader sr = new StreamReader("config.txt");

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
