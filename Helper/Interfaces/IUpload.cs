namespace AccountShop.Helper.Interfaces
{
    public interface IUpload
    {
        public  Task<bool> Upload(IFormFile file,string path);
        public  Task<bool> Upload(List<IFormFile> files,string path);
    }
}
