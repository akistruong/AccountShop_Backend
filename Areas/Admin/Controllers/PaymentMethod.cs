using AccountShop.Areas.Admin.Business_Layer;
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
        PaymentMethodBUS paymentMethodBUS;
        public PaymentMethod()
        {
            paymentMethodBUS = new PaymentMethodBUS();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var methods = paymentMethodBUS.Select();
                return Ok(methods);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var methods = paymentMethodBUS.Select(id);
                return Ok(methods);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
        [HttpPost]  
        public IActionResult Post(Models.Paymentmethod method)
        {
            try
            {
                var result = paymentMethodBUS.InsertToDatabase(method);
                return Ok(result);  
            }catch (Exception ex) { 
                throw ex;
            }
        }
        [HttpPut]
        public IActionResult Put(Models.Paymentmethod method)
        {
            try
            {
                var result = paymentMethodBUS.UpdateToDatabase(method);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = paymentMethodBUS.Delete(id);
                return result==true?Ok():NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
