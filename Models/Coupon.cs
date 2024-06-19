using AccountShop.Const;
using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class Coupon
{
    public string CouponId { get; set; } = null!;

    public string? CouponDsc { get; set; }
    public bool? IsActive { get; set; } = true;
    public CouponType CouponType { get; set; } = CouponType.FixedPrice;
    public int MaxUses { get; set; }
    public decimal Value { get; set; }
    public int MaxUses_Per_User { get; set; }
    public int UsedCount { get; set; }
    public int MinQtyOrder { get; set; }
    public CouponApplyTo ApplyTo { get; set; } = CouponApplyTo.All;
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeleteAt { get; set; }

    public DateTime? CouponExpiration { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
    public virtual ICollection<Coupon_Product> Coupon_Products { get; set; } = new List<Coupon_Product>();

}
