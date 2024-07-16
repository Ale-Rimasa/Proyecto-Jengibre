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


    }
}
