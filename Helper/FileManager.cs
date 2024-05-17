using AccountShop.Helper.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AccountShop.Helper
{
    public class FileManager : IFileManger
    {
        public  async Task<bool> Delete( string path)
        {
            if(File.Exists(path)) { 
                File.Delete(path);
                return true;

            }
        return false;
        }

        public  async Task<bool> Upload(IFormFile file, string path)
        {
            var result = await Uploader.Upload(file, path);
            return result;
        }
    }
}
