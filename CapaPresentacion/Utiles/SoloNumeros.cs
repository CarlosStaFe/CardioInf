namespace CapaPresentacion.Utiles
{
    public class SoloNumeros
    {
        public int Validar(int tecla)
        {
            switch (tecla)
            {
                case 08:            // BackSpace
                case 13:            // Enter
                case 46:            // .
                case 48:            // 0
                case 49:            // 1
                case 50:            // 2
                case 51:            // 3
                case 52:            // 4
                case 53:            // 5
                case 54:            // 6
                case 55:            // 7
                case 56:            // 8
                case 57:            // 9
                    return tecla;
                default:
                    tecla = 0;
                    break;
            }

            return tecla = 0;

        }
    }
}
