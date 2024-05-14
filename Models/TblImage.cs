using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class TblImage
{
    public int ImageId { get; set; }

    public string? ImageUrl { get; set; }

    public string? ImageDsc { get; set; }

    public string? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
