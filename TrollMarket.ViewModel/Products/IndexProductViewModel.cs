using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel.Products
{
    public class IndexProductViewModel
    {
        public string searchName { get; set; }
        public string searchCategory { get; set; }
        public string searchDescription { get; set; }
        public IEnumerable<ProductViewModel> listProduct { get; set; }
    }
}
