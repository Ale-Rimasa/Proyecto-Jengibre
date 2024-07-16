using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Useer
    {
        public int ID_User { get; set; }
        public string NameUser { get; set; }
        public string SurnameUser { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        public bool Reseet { get; set; }
        public bool Active { get; set; }
    }
}
