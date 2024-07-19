using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

//Referencias para enviar un correo electronico.
using System.Net.Mail;
using System.Net;
using System.IO;

namespace CapaNegocio
{
    public class CN_Resource
    {
        //Clave automatica  generada para enviar al usuario
        public static string GenerateClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0,6);
            return clave;
        }


        public static bool SentMail(string mail, string subject, string menssage)
        {
            bool sentMail = false;

            try
            {   //Configuracion del mensaje
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(mail); //A quien le voy a enviar el mensaje
                mailMessage.From = new MailAddress("alerimasa92@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = menssage;
                mailMessage.IsBodyHtml=true;

                //Configurar el servidor que se encarga para enviar el mensaje
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("",""),
                    Host= "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };

                smtp.Send(mailMessage);
                sentMail= true;
            }
            catch(Exception ex)
            {
                sentMail = false;
            }
            return sentMail;
        }


        //Encriptacion de texto en SHA256
        public static string ConvertSha256(string text)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash= SHA256Managed.Create()) 
            { 
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();   
            }
        }

    }
}
