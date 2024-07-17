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
                string clave = "test123";
                obj.Clave = CN_Resource.ConvertSha256(clave);


                return objCapaDato.Register(obj, out Menssage);

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
