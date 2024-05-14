using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Product : ControllerBase
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        [HttpGet]
        public IActionResult Index()
        {

            var products = context.Products;
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post(Models.Product product)
        {
            try
            {
                var result = context.Products.Add(product);
                return result != null ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult Put(Models.Product product)
        {
            try
            {
                var result = context.Products.Update(product);
                return result != null ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = context.Products.FirstOrDefault(x => x.ProductId == id);
                if (product != null)
                {

                    var result = context.Products.Remove(product);
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
