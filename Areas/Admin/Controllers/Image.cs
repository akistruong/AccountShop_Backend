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
        [HttpPost]
        public async Task<IActionResult> UploadImages(List<IFormFile> files, string productID)
        {
            var trans = context.Database.BeginTransaction();
            try
            {
                var product = context.Products.FirstOrDefault(x=>x.ProductId== productID);  
                if (product == null)
                {
                    return NotFound();
                }
                var folder = "wwwroot//source//products//images//" + productID.Trim();
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                foreach (var file in files)
                {
               var path = "wwwroot//source//products//images//" + productID.Trim() + "//"+file.FileName;
                bool result = await Uploader.Upload(file, path);
                    var image = new Models.TblImage();
                    image.ImageUrl = path;
                    image.ProductId = productID;    
                    context.TblImages.Add(image);
                    
                }
                context.SaveChanges();
                trans.Commit();
                return Ok(files);
            }
            catch (Exception ex) {
                trans.Rollback();
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
