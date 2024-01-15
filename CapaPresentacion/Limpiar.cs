using System.Windows.Forms;

namespace CapaPresentacion
{
    class Limpiar
    {
        public void LimpiarCampos(Form xForm)
        {
            foreach (Control item in xForm.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = string.Empty;
                }
                else if (item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = -1;
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
