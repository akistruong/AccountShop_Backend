using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Paymentmethod
{
    public int MethodId { get; set; }

    public string? MethodName { get; set; }

    public string? MethodDsc { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
