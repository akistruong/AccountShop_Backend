using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class VariantAttribute
{
    public string OptionValueID { get; set; }
    public int VariantId { get; set; }

    public virtual Variant? Variant { get; set; } = null!;
    public virtual OptionValue? OptionValue { get; set; } = null!;
}
