using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Image : ControllerBase
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        ImageBUS imageBUS;
        public Image() {
            imageBUS = new ImageBUS();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var images = imageBUS.Select();
                return Ok(images);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetImagesByProduct(string id) {
            try
            {
                var images = imageBUS.SelectImagesByProduct(id);
                return Ok(images);
            }catch (Exception ex) {
                throw ex;
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                   var result = imageBUS.Delete(id);    
                return result==true? Ok(): NotFound();    
            }catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
