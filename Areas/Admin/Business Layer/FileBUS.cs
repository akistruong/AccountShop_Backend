using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Helper;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class FileBUS : IUpload
    {
        ProductDAO productDAO;
        ImageDAO imageDAO;
        FileManager fileManager;    
        public FileBUS() {
            productDAO = new ProductDAO();
            imageDAO = new ImageDAO();
            fileManager = new FileManager();    
        }
        public async Task<bool> UploadProductImage(IFormFile file, string productID)
        {
            var product = productDAO.SelectByID(productID);
            if(product == null ) {
                return false;
            }
            var folder = "wwwroot//source//products//images//" + productID.Trim();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var path = "wwwroot//source//products//images//" + productID.Trim() + "//" + file.FileName;
             await fileManager.Upload(file,path);
            product.ProductImage = file.FileName;
            productDAO.Update(product);
            return true;
        }

        public async Task<bool> UploadProductImages(List<IFormFile> files, string productID)
        {
            var product = productDAO.SelectByID(productID);
            if (product == null)
            {
                return false;
            }
            var folder = "wwwroot//source//products//images//" + productID.Trim();
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            foreach (var file in files)
            {
                var path = "wwwroot//source//products//images//" + productID.Trim() + "//" + file.FileName;
                await fileManager.Upload(file, path);
                var image = new Models.TblImage();
                image.ImageUrl = path;
                image.ProductId = productID;
                imageDAO.Update(image);
            }
            return true;
        }
    }
}
