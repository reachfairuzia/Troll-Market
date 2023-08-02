using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel.Products
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Discontinue { get; set; }

        public string ProductName { get; set; }

        public double? Price { get; set; }
        public string StringPrice { get; set; }

        public string SellerName { get; set; }
    }
}
