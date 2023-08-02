﻿using System;
using System.Collections.Generic;

namespace TrollMarket.DataAccess.Models;

public partial class Buyer
{
    public string Username { get; set; } = null!;

    public string? Address { get; set; }

    public decimal? Balance { get; set; }

    public string Name { get; set; } = null!;

    public int Id { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
