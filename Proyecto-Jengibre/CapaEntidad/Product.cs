using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Product
    {
        public int ID_Product { get; set; }
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        public Mark oMark { get; set; }
        public Category oCategory { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string RouteImage { get; set; }
        public string NameImage { get; set; }
        public bool Active { get; set; }
    }
}
