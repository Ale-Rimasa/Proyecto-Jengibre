using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ShoppingCart
    {
        public int ID_ShopingCart { get; set; }
        public Client oClient { get; set; }
        public Product oProduct { get; set; }
        public int Quantity { get; set; }
    }
}
