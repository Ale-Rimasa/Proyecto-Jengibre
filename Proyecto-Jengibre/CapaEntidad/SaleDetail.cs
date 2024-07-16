using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SaleDetail
    {
        public int ID_SaleDetail { get; set; }

        public int ID_Sale { get; set; }

        public Product oProduct { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public string IDTransaction { get; set; } //Atributo para sistema de pago.
    }
}
