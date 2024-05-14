using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Category : Controller
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var categorys = context.Categories; 
                return Ok(categorys);
            }
            catch (Exception ex) {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Post(Models.Category category)
        {
            try
            {
                var result = context.Categories.Add(category);
                context.SaveChanges();
                return Ok(result);
            }catch (Exception ex) {
                return NotFound();
                    }
        }
        [HttpPut]
        public IActionResult Put(Models.Category category) {
            try
            {

                context.Entry(category).State = EntityState.Modified;
                context.SaveChanges();
                return Ok(category);
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
                var cat = context.Categories.FirstOrDefault(x => x.CategoryId == id);
              var result=  context.Categories.Remove(cat);
                return Ok();
            }
            catch (Exception ex) {
                return NotFound();
            }
        }
    }
}
