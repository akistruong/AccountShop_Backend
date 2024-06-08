using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class CouponBUS : ICoupon
    {
        CouponDAO couponDAO;
        public CouponBUS(AccountShopContext context) { 
            couponDAO = new CouponDAO(context);    
        }

        public bool Delete(string id)
        {
            return couponDAO.Delete(id);
        }

       

        public List<Coupon> Get()
        {
            return couponDAO.Select();
        }

        public Coupon Get(string id)
        {
            return couponDAO.Select(id);
        }

        public Coupon Insert(Models.Coupon coupon)
        {
            return couponDAO.Insert(coupon);
        }

        public Coupon Update(Coupon coupon )
        {
            return couponDAO.Update(coupon);
        }
    }
}
