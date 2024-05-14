using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Variant : Controller
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        [HttpGet]
        public IActionResult Index()
        {
            var variants = context.Variants;
            return Ok(variants);    
        }
        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var variant = context.Variants.FirstOrDefault(x => x.VariantId == id);
            return variant != null ? Ok(variant) : NotFound(); 
        }
        [HttpPost]
        public IActionResult Post(Models.Variant variant)
        {
            try
            {
                var result = context.Variants.Add(variant);
                context.SaveChanges();
                return Ok(result);
            }catch (Exception ex) { 
                throw ex;   
            }
        }
        [HttpPut]
        public IActionResult Put(Models.Variant variant)
        {
            try
            {
                context.Entry(variant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]    
        public IActionResult Delete(int id) {
            try
            {
                var variant = context.Variants.FirstOrDefault(x => x.VariantId == id);
                if(variant!=null)
                {
                    context.Variants.Remove(variant);
                    context.SaveChanges() ; 
                    return Ok();
                }
                return NotFound();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
