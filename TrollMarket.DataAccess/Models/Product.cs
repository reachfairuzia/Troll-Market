using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public bool? Discontinue { get; set; }

    public string? ProductName { get; set; }

    public double? Price { get; set; }

    public int? SellerId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual Seller? Seller { get; set; }
}
