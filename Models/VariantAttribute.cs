using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class VariantAttribute
{
    public int AttributeId { get; set; }

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int VariantId { get; set; }

    public virtual Variant Variant { get; set; } = null!;
}
