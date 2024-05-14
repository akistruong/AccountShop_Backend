using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Coupon
{
    public string CouponId { get; set; } = null!;

    public string? CouponDsc { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public DateTime? CouponExpiration { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
