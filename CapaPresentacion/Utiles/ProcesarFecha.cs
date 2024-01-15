using System;

namespace CapaPresentacion.Utiles
{
    public class ProcesarFecha
    {
        int pos1, pos2;
        string dd, mm, yyyy;

        public string Procesar(string fecha)
        {
            pos1 = fecha.IndexOf('/');
            pos2 = fecha.IndexOf('/', pos1 + 1);

            if (pos1 < 5)
            {
                dd = fecha.Substring(0, pos1);
            }
            else
            {
                yyyy = fecha.Substring(0, pos1);
            }

            mm = fecha.Substring(pos1 + 1, ((pos2 - 1) - pos1));

            if (pos2 < 8)
            {
                yyyy = fecha.Substring(pos2 + 1, 4);
            }
            else
            {
                dd = fecha.Substring(pos2 + 1, 2);
            }

            dd = new PonerCeros().Proceso(dd, 2);
            mm = new PonerCeros().Proceso(mm, 2);

            if (Convert.ToInt32(yyyy) < 100)
            {
                yyyy = "20" + yyyy;
            }

            fecha = yyyy + "-" + mm + "-" + dd;

            return fecha;
        }
    }
}
