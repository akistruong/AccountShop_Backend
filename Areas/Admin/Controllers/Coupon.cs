using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Coupon : ControllerBase
    {
        CouponBUS couponBUS;
        public Coupon()
        {
            couponBUS = new CouponBUS();    
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var coupons = couponBUS.Get();
                return Ok(coupons);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(string? id) {
            try
            {
                  var coupon = couponBUS.Get(id);    
                return coupon!=null? Ok(coupon):NotFound();
            }catch (Exception ex)
            {
                throw ex;   
            }
        }
        [HttpPost]
        public IActionResult Post(Models.Coupon coupon)
        {
            try
            {
                couponBUS.Insert(coupon);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut]
        public IActionResult Put(Models.Coupon coupon)
        {
            try
            {
                couponBUS.Update(coupon);   
                return Ok(coupon);
            }catch(Exception ex) {
                throw ex;
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(string ? id)
        {

            try
            {
                var result = couponBUS.Delete(id);  
                return result==false?NotFound(): Ok();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
