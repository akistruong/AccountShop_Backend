using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class VariantDAO
    {
         AccountShopContext context;
        public VariantDAO(AccountShopContext _context)
        {
            this.context = _context;    
        }

        public List<Models.Variant> Select ()
        {
            return context.Variants.ToList();
        }
        public Models.Variant Select(int id)
        {
            return context.Variants.Find (id);
        }
        public List<Models.Variant> SelectVariantsByProduct (string id) {
            return context.Variants.Where(x=>x.ProductId == id).ToList();            
        }
        public Models.Variant Insert(Models.Variant variant) { 
            context.Variants.Add (variant);    
            context.SaveChanges();
            return variant;
        }
        public Models.Variant Update (Models.Variant variant)
        {
            context.Entry(variant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges ();
            return variant;
        }
        public bool Delete (int id)
        {
            var variant = context.Variants.Find (id);
            if (variant != null) { 
                context.Variants.Remove (variant);  
                return true;
            }
            return false;
        }
    }
}
