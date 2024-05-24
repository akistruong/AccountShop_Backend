using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Orderdetail
{

    public int OrderId { get; set; }
    public int VariantID { get; set; }
    public int? OdtQty { get; set; }
    public decimal? OdtPrice { get; set; }

    public virtual TblOrder Order { get; set; } = null!;
    public virtual Variant Variant { get; set; } = null!;

}
