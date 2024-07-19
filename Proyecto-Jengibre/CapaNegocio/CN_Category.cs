using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Category
    {
        private CD_Category objCapaDato = new CD_Category();

        public List<Category> List() //hacemos un metodo que nos retorne el metodo listar. Se podria hacer logicas aca adentro (buscamos algun idusuario, filtro, etc)
        {
            return objCapaDato.List();
        }

        public int Register(Category obj, out string Menssage)
        {
            Menssage = string.Empty;

            if (string.IsNullOrEmpty(obj.DescriptionCategory) || string.IsNullOrEmpty(obj.DescriptionCategory))
            {
                Menssage = "La descripcion de la categoria no puede ser vacio";
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

        public bool Edit(Category obj, out string Menssage)
        {
            Menssage = string.Empty;

            if (string.IsNullOrEmpty(obj.DescriptionCategory) || string.IsNullOrEmpty(obj.DescriptionCategory))
            {
                Menssage = "La descripcion de la categoria no puede ser vacio";
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
