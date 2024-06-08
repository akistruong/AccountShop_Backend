using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Upload : ControllerBase
    {
        FileBUS uploadBUS;
        public Upload(AccountShopContext context)
        {
            uploadBUS = new FileBUS(context);    
        }
        [HttpPost("UploadProductImage/{productID}")]
        public async Task<IActionResult> UploadProductImage(IFormFile file,string productID)
        {
            var result = await uploadBUS.UploadProductImage(file, productID);
            return result==true ? Ok(result) : BadRequest(result);  
        }
        [HttpPost("UploadProductImages/{productID}")]
        public async Task<IActionResult> UploadProductImages(List<IFormFile> files, string productID)
        {
            var result = await uploadBUS.UploadProductImages(files, productID);
            return result == true ? Ok(result) : BadRequest(result);
        }
    }
}
