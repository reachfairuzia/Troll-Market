using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrollMarket.ViewModel.Buyer;

namespace TrollMarket.ViewModel.Seller
{
    public class IndexProfileSellerViewModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Balance { get; set; }
        public List<TransactionHistoryViewModel> History { get; set; }
    }
}
