using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel.Buyer
{
    public class TopupDanaViewModel
    {
        public int BuyerId { get; set; }
        [MinimalTopupValidation]
        public decimal Dana { get; set; }
    }
}
