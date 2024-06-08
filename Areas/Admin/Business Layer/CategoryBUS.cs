using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class CategoryBUS : ICategory
    {
        CategoryDAO categoryDAO;

        public CategoryBUS(AccountShopContext context) { 
            categoryDAO = new CategoryDAO(context);    
        }    
        public List<Models.Category> Get()
        {
            return categoryDAO.Select();
        }
        public Models.Category InsertToDatabase(Models.Category category)
        {
           return categoryDAO.Insert(category);   

        }
        public Models.Category UpdateToDatabase (Models.Category category)
        { 
            return categoryDAO.Update(category);    
        }
        public bool Delete(int id) 
        {
            return categoryDAO.Delete(id);  
        }

        
        public Category Get(int id)
        {
            return categoryDAO.Select(id);   
        }
    }
}
