using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Useers
    {
        private CD_Useers objCapaDato = new CD_Useers();

        public List<Useer> List() //hacemos un metodo que nos retorne el metodo listar. Se podria hacer logicas aca adentro (buscamos algun idusuario, filtro, etc)
        {
            return objCapaDato.List();
        }
        public int Register(Useer obj, out string Menssage)
        {
            Menssage = string.Empty;

            if (string.IsNullOrEmpty(obj.NameUser) || string.IsNullOrEmpty(obj.NameUser))
            {
                Menssage = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SurnameUser) || string.IsNullOrEmpty(obj.SurnameUser))
            {
                Menssage = "El Apellido del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Mail) || string.IsNullOrEmpty(obj.Mail))
            {
                Menssage = "El Mail del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Menssage))
            {

                //Para enviar correo electronico para que pueda acceder
                string password = CN_Resource.GenerateClave();
                string subject = "Creacion de Cuenta";
                string menssaje_mail = "<h3>Su cuenta fue creada correctamente</h3></br><p>Su contraseña para acceder es : !password!</p>";
                menssaje_mail = menssaje_mail.Replace("!password!", password);

                bool SendMail = CN_Resource.SentMail(obj.Mail, subject, menssaje_mail);

                if (SendMail)
                {
                    obj.Clave = CN_Resource.ConvertSha256(password);
                    return objCapaDato.Register(obj, out Menssage);

                }
                else
                {
                    Menssage = "No se puede enviar el correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }


        public bool Edit(Useer obj, out string Menssage)
        {
            Menssage = string.Empty;

            if (string.IsNullOrEmpty(obj.NameUser) || string.IsNullOrEmpty(obj.NameUser))
            {
                Menssage = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.SurnameUser) || string.IsNullOrEmpty(obj.SurnameUser))
            {
                Menssage = "El Apellido del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.Mail) || string.IsNullOrEmpty(obj.Mail))
            {
                Menssage = "El Mail del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Menssage))
            {
                return objCapaDato.Edit(obj, out Menssage);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminate(int id, out string Menssage)
        {
            return objCapaDato.Eliminate(id, out Menssage);
        }


    }
}
