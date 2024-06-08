using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class CategoryDAO
    {
        AccountShopContext context;

        public CategoryDAO(AccountShopContext context)
        {
            this.context = context;
        }

        public List<Category> Select()
        {
            var categories = context.Categories.ToList();
            return categories;
        }
        public Category Select(int id)
        {
            return context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }
        public Category Insert(Category category)
        {
            var result = context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }
        public Category Update(Category category)
        {
            context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return category;
        }
        public bool Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if (category == null)
            {
                return false;
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return true;
        }

    }
}
