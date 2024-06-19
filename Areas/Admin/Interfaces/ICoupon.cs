using AccountShop.Dtos;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Interfaces
{
    public interface ICoupon
    {
        public List<Models.Coupon> Get();
        public Models.Coupon Get(string id);
        public Models.Coupon GetProductByCouponID(string id);
        public CouponAmountResponse GetCouponAmount(Models.TblOrder order);
        public Models.Coupon Insert(Models.Coupon coupon);
        public bool Delete(string id);
        public Models.Coupon Update(Models.Coupon coupon);
    }
}
