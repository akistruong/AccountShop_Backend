using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.DataLayer
{
    public class CategoryDAO
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        public List<Category> Select()
        {
            var categories = context.Categories.ToList();   
            return categories;
        }
        public Category GetCategory(int id) {
            return context.Categories.FirstOrDefault(x => x.CategoryId == id);
        }
        public Models.Category Insert(Models.Category category)
        {
            var result = context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }
        public Models.Category Update(Models.Category category)
        {
            var result = context.Categories.Update(category);
            context.SaveChanges();
            return category;
        }
        public bool Delete(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            if(category == null)
            {
                return false;
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return true;
        }

    }
}
