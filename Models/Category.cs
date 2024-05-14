using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryImage { get; set; }

    public int? CategoryRootId { get; set; }

    public virtual Category? CategoryRoot { get; set; }

    public virtual ICollection<Category> InverseCategoryRoot { get; set; } = new List<Category>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
