using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class History
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public int? Quantity { get; set; }

    public int? SellerId { get; set; }

    public int? ShipmentId { get; set; }

    public double? TotalPrice { get; set; }

    public virtual Buyer? Buyer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Seller? Seller { get; set; }

    public virtual Shipment? Shipment { get; set; }
}
