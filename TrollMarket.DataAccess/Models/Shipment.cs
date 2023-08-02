using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class Shipment
{
    public int ShipperId { get; set; }

    public bool? Service { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
