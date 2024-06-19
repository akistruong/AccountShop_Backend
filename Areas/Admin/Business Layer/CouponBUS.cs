using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Dtos;
using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class CouponBUS : ICoupon
    {
        CouponDAO couponDAO;
        ProductDAO productDAO;
        AccountShopContext _context;
        public CouponBUS(AccountShopContext context)
        {
            couponDAO = new CouponDAO(context);
            productDAO = new ProductDAO(context);
            this._context = context;    
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
        /*
         Order{
            orderdetail:[
                {
            qty:1,
            variantID:1   
        },
        ]
        }
         */
        public CouponAmountResponse GetCouponAmount(TblOrder order)
        {
            var items = order.Orderdetails.ToList();
            var CouponAmountResponse  = new CouponAmountResponse(); 
            var Coupon = couponDAO.Select(order.CouponId);
            if (items.Count>0)
            {
               
                OrderItemHelper orderItemHelper = new OrderItemHelper(this._context);
                var VariantsFromServer = orderItemHelper.GetVariantsByOrderItems(items);
                var PriceBeforeDiscount = VariantsFromServer.Sum(x=>x.VariantPrice);
                var Amount = 0.0;
                decimal PriceAfterDiscount = 0;
                if(Coupon !=null)
                {
                    Amount = (double)(((int)Coupon.CouponType) == 0 ? Coupon.Value : (decimal)(PriceBeforeDiscount * (Coupon.Value) / 100));
                    PriceAfterDiscount = (decimal)PriceBeforeDiscount - (decimal)Amount;
                    CouponAmountResponse.Amount = (decimal)Amount;
                    CouponAmountResponse.TotalPrice = (decimal)PriceBeforeDiscount;
                    CouponAmountResponse.FinalPrice = (decimal)PriceAfterDiscount;
                }

            }
            return CouponAmountResponse;
        }

      
        public Coupon GetProductByCouponID(string id)
        {
            throw new NotImplementedException();
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
