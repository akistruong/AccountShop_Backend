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
        AccountShopContext context = DatabaseInstance.GetInstance();
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var coupons = context.Coupons;
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
                  var coupon = context.Coupons.FirstOrDefault(x=>x.CouponId == id);
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
                context.Coupons.Add(coupon);
                context.SaveChanges();
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
                context.Entry(coupon).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
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
                var coupon = context.Coupons.FirstOrDefault(x => x.CouponId == id);
                if (coupon != null)
                {
                    context.Coupons.Remove(coupon);
                    context.SaveChanges();
                return Ok();
                }
                return NotFound(); 
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
