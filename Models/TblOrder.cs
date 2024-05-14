using System;
using System.Collections.Generic;

namespace AccountShop.Models;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? OrderQty { get; set; }

    public decimal? OrderPrice { get; set; }

    public bool? OrderStatus { get; set; }

    public int? PaymentMethodId { get; set; }

    public string? CouponId { get; set; }

    public string? Username { get; set; }

    public bool? Ischeckout { get; set; }

    public virtual Coupon? Coupon { get; set; }

    public virtual ICollection<Orderdetail> Orderdetails { get; set; } = new List<Orderdetail>();

    public virtual Paymentmethod? PaymentMethod { get; set; }

    public virtual TblUser? UsernameNavigation { get; set; }
}
