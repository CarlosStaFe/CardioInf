using System.Windows.Forms;

namespace CapaPresentacion
{
    class Limpiar
    {
        public void LimpiarCampos(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedItem = 1;
                }
            }
            //foreach (var grupo in gb.Controls)
            //{
            //    if (grupo is TextBox)
            //    {
            //        ((TextBox)grupo).Clear();
            //    }
            //    else if (grupo is ComboBox)
            //    {
            //        ((ComboBox)grupo).SelectedIndex = 0;
            //    }
            //}
        }
    }
}
