using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Sale
    {
        public int ID_Sale { get; set; }
        public int ID_Client { get; set; }
        public int ProductQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public string Contact { get; set; }
        public string ID_District { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string DateSale { get; set; }
        public string IDTransaction { get; set; }

        public List<SaleDetail> oSaleDetail { get; set; }

    }
}
