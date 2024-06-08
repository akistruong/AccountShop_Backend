using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class ImageDAO
    {
        AccountShopContext context;

        public ImageDAO(AccountShopContext context)
        {
            this.context = context;
        }

        public List<Models.TblImage> Select()
        {
            return context.TblImages.ToList();
        }
        public Models.TblImage Select(int id)
        {
            return context.TblImages.Find(id);
        }
        public List<Models.TblImage> GetImagesByProduct(string id) {
            return context.TblImages.Where(x=>x.ProductId == id).ToList();  
        }
        public Models.TblImage Insert(Models.TblImage image) { 
            context.TblImages.Add(image);
            context.SaveChanges();
            return image;
        }
        public Models.TblImage Update(Models.TblImage image)
        {
            context.Entry(image).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return image;
        }
        public bool Delete(int id) { 
            var image = context.TblImages.Find(id); 
            if (image != null)
            {
                context.TblImages.Remove(image);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
