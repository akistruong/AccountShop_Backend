namespace AccountShop.Areas.Admin.Interfaces
{
    public interface IUpload
    {
        public Task<bool> UploadProductImage(IFormFile file,string productID);
        public Task<bool> UploadProductImages(List<IFormFile> files, string productID);
    }
}
