using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Orderdetail
{
    public int? OdtQty { get; set; }

    public decimal? OdtPrice { get; set; }

    public int VariantId { get; set; }

    public int OrderId { get; set; }

    public virtual TblOrder Order { get; set; } = null!;

    public virtual Variant Variant { get; set; } = null!;
}
