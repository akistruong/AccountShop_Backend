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
        AccountShopContext context = DatabaseInstance.GetInstance();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var orders = context.TblOrders;
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
                var order = context.TblOrders.FirstOrDefault(x=>x.OrderId == id);
                return order!=null? Ok(order):NotFound();
            }catch (Exception ex) {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult Post(Models.TblOrder order) {
            try
            {
                var result= context.TblOrders.Add(order);
                context.SaveChanges();
                return Ok(result);
            }catch  (Exception ex)
            {
                throw ex;

            }
        }
    }
}
