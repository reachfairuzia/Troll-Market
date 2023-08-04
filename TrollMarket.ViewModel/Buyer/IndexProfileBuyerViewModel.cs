using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel.Buyer
{
    public class IndexProfileBuyerViewModel
    {
        public int BuyerId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Balance { get; set; }
        public List<TransactionHistoryViewModel> History { get; set; }
    }
}
