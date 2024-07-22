using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Mark
    {
        private CD_Mark objCapaDato = new CD_Mark();

        public List<Mark> List() //hacemos un metodo que nos retorne el metodo listar. Se podria hacer logicas aca adentro (buscamos algun idusuario, filtro, etc)
        {
            return objCapaDato.List();
        }


        public int Register(Mark obj, out string Menssage)
        {
            Menssage = string.Empty;

            if (string.IsNullOrEmpty(obj.DescriptionMark) || string.IsNullOrEmpty(obj.DescriptionMark))
            {
                Menssage = "La descripcion de la marca no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Menssage))
            {
                return objCapaDato.Register(obj, out Menssage);
            }
            else
            {
                return 0;
            }
        }

        public bool Edit(Mark obj, out string Menssage)
        {
            Menssage = string.Empty;

            if (string.IsNullOrEmpty(obj.DescriptionMark) || string.IsNullOrEmpty(obj.DescriptionMark))
            {
                Menssage = "La descripcion de la marca no puede ser vacio";
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
