using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public decimal? ProductPrice { get; set; }

    public string? ProductImage { get; set; }

    public string? ProductDesciption { get; set; }

    public string? ProductSlug { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductContent { get; set; }

    public string? RootId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Product> InverseRoot { get; set; } = new List<Product>();

    public virtual Product? Root { get; set; }

    public virtual ICollection<TblImage> TblImages { get; set; } = new List<TblImage>();

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
    public virtual ICollection<Iventory> Iventories { get; set; } = new List<Iventory>();
    public virtual ICollection<Coupon_Product> Coupon_Products { get; set; } = new List<Coupon_Product>();
}
