using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Category : Controller
    {
        CategoryBUS categoryBUS;
        public Category(AccountShopContext context) {
            categoryBUS = new CategoryBUS(context);
        }   
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var categorys = categoryBUS.Get(); 
                return Ok(categorys);
            }
            catch (Exception ex) {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = categoryBUS.Get(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Post(Models.Category category)
        {
            try
            {
                var result = categoryBUS.InsertToDatabase(category);
                return Ok(result);
            }catch (Exception ex) {
                return NotFound();
                    }
        }
        [HttpPut]
        public IActionResult Put(Models.Category category) {
            try
            {
                var result = categoryBUS.UpdateToDatabase(category);               
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(ex);    
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
              var result= categoryBUS.Delete(id);
                return Ok();
            }
            catch (Exception ex) {
                return NotFound();
            }
        }
    }
}
