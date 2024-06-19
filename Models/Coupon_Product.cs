namespace AccountShop.Models
{
    public class Coupon_Product
    {
        public string CouponID { get; set; }
        public string ProductID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Coupon Coupon { get; set; }
    }
}
