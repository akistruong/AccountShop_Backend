using Microsoft.AspNetCore.Http;

namespace AccountShop.Helper
{
    public  class Uploader
    {
        public static async Task<bool>Upload(IFormFile file,string path)
        {
            try
            {
                var filePath = Path.GetTempFileName();
                //if (!Directory.Exists(path))
                //{
                //    Directory.CreateDirectory(folder);
                //}
                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
