using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Order : Controller
    {
        OrderBus orderBUS;
        public Order(AccountShopContext context) { 
            orderBUS = new OrderBus(context);  
        }  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var orders = orderBUS.Get();
                return Ok(orders);
            }catch (Exception ex) {
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = orderBUS.Get(id);
                return order!=null? Ok(order):NotFound();
            }catch (Exception ex) {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult Post(Models.TblOrder order) {
            try
            {
                var result= orderBUS.CreateOrder(order);
                return Ok(result);
            }catch  (Exception ex)
            {
                throw ex;

            }
        }
        [HttpPut]
        public IActionResult Put(Models.TblOrder order)
        {
            try
            {
                var result = orderBUS.UpdateOrder(order);
                return Ok(result);  
            }catch(Exception ex) {
                throw ex;
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try
            {
                var result = orderBUS.Delete(id);
                return result==true?Ok(result):NotFound();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
