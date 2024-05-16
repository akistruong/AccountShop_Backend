namespace AccountShop.Helper.Interfaces
{
    public abstract class IUpload
    {
        public abstract Task<bool> UploadFile(IFormFile file,string path);
        public abstract Task<bool> UploadMutipleFile(List<IFormFile> files,string path);
    }
}
