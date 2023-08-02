using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel.Shipment
{
    public class UpsertShipmentViewModel
    {
        public int ShipperId { get; set; }

        public bool? Service { get; set; }

        public string? Name { get; set; }

        public double? Price { get; set; }
    }
}
