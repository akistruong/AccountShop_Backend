using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class PaymentMethod : Controller
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        [HttpGet]   
        public IActionResult Index()
        {
            try
            {
                var methods = context.Paymentmethods;
                return Ok(methods);
            }
            catch (Exception ex)
            {

                return NotFound();  
            }
            return View();
        }
        [HttpPost]  
        public IActionResult Post(Models.Paymentmethod method)
        {
            try
            {
                var result = context.Paymentmethods.Add(method);
                context.SaveChanges();
                return Ok(result);  
            }catch (Exception ex) { 
                return NotFound(ex);
            }
        }
        [HttpPut]
        public IActionResult Put(Models.Paymentmethod method)
        {
            try
            {
                context.Entry(method).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var payment = context.Paymentmethods.FirstOrDefault(x => x.MethodId == id);
                var result = context.Paymentmethods.Remove(payment);
                context.SaveChanges();  
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
