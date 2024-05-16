namespace AccountShop.Helper.Interfaces
{
    public interface IFileManger
    {
        public Task<bool> Upload(IFormFile file,string path);
        public Task<bool> Delete(string path);
    }
}
