using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class CouponDAO
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        public List<Models.Coupon> Select()
        {
            return context.Coupons.ToList();    
        }

        public Models.Coupon SelectCoupon(string couponId) {
            return context.Coupons.FirstOrDefault(x => x.CouponId == couponId);
        }
        public Models.Coupon Insert(Models.Coupon coupon) { 
            var result = context.Coupons.Add(coupon);
            context.SaveChanges();
            return coupon;
        }
        public Models.Coupon Update(Models.Coupon coupon) { 
            var result = context.Coupons.Update(coupon);    
            context.SaveChanges();
            return coupon;  
        }
        public bool Delete (string couponId)
        {
            var coupon = context.Coupons.FirstOrDefault(x=>x.CouponId == couponId); 
            if(coupon != null)
            {
                context.Coupons.Remove(coupon); 
                context.SaveChanges() ;
                return true;
            }
            return false;
        }
    }
}
