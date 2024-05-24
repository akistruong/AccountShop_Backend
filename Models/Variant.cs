﻿using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Variant
{
    public int VariantId { get; set; }

    public string? ProductId { get; set; }

    public decimal? VariantPrice { get; set; }

    public string? VariantSlug { get; set; }

    public int? VariantQty { get; set; }

    public string? VariantName { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<VariantAttribute> VariantAttributes { get; set; } = new List<VariantAttribute>();
}
