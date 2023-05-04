using System;
using System.Net.Mail;

namespace CapaPresentacion.Utiles
{
    public class EnviarCorreo
    {
        public bool EnviarMail(string mailorigen, string password, string maildestino, string asunto, string cuerpo, string path)
        {
            bool enviado = false;

            try
            {
                using (MailMessage oMail = new MailMessage(mailorigen, maildestino, asunto, cuerpo))
                {
                    oMail.Attachments.Add(new Attachment(path));
                    oMail.IsBodyHtml= false;

                    using (SmtpClient oSmtpCliente = new SmtpClient("smtp.hostinger.com"))
                    {
                        oSmtpCliente.EnableSsl = true;
                        oSmtpCliente.UseDefaultCredentials = false;
                        oSmtpCliente.Port = 587;
                        oSmtpCliente.Credentials = new System.Net.NetworkCredential(mailorigen, password);

                        oSmtpCliente.Send(oMail);

                        enviado = true; 
                    }
                }
            }
            catch(Exception)
            {
                enviado = false;
            }

            return enviado;
        }
    }
}
