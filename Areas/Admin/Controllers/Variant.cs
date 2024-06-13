using AccountShop.Areas.Admin.Business_Layer;
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
        VariantBUS variantBUS;
        public Variant(AccountShopContext _context)
        {
            variantBUS = new VariantBUS(_context);  
        }
        [HttpGet]
        public IActionResult Get()
        {
            var variants = variantBUS.Get();
            return Ok(variants);    
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var variant = variantBUS.Get(id);
            return variant != null ? Ok(variant) : NotFound(); 
        }
        [HttpGet("GetByProduct/{productID}")]
        public IActionResult GetByProduct(string productID)
        {
            var variant = variantBUS.GetByProduct(productID);
            return variant != null ? Ok(variant) : NotFound();
        }
        [HttpPost("GetByOptionValueID")]
        public IActionResult GetByProduct(List<string> ids)
        {
            var variant = variantBUS.GetVariantByOptionValue(ids);
            return variant != null ? Ok(variant) : NotFound();
        }
        [HttpPost]
        public IActionResult Post(Models.Variant variant)
        {
            try
            {
                var result = variantBUS.InsertToDatabase(variant);
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
                var result = variantBUS.UpdateToDatabase(variant);
                return Ok(result);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("{id}")]    
        public IActionResult Delete(int id) {
            try
            {
                var variant =variantBUS.Delete(id);
                return variant==null? NotFound():Ok();  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
