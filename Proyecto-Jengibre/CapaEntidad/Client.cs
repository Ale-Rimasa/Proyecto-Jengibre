using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Client
    {
        public int ID_Client { get; set; }
        public string NameClient { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        public bool Reseet { get; set; }
    }
}
