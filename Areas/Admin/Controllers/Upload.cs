using AccountShop.Areas.Admin.Business_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Upload : ControllerBase
    {
        FileBUS uploadBUS;
        public Upload()
        {
            uploadBUS = new FileBUS();    
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
