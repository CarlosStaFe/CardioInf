namespace CapaPresentacion.Utiles
{
    public class PonerCeros
    {
        public string Proceso(string numero, int largo)
        {
            string ceros = "";
            string nroconceros = numero;

            int longitud = nroconceros.Length;

            if (longitud < largo)
            {
                int cantidad = largo - longitud;
                for( int i = 0 ; i < cantidad; i++)
                {
                    ceros = ceros + "0";
                }
            }
            nroconceros = ceros + numero;

            return nroconceros;
        }
    }
}
