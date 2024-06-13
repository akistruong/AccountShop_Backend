using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class OptionBUS
    {
        OptionDAO optionDAO;
        public OptionBUS( AccountShopContext context)
        {
                       optionDAO = new OptionDAO(context);  
        }
        public Option Get(string id)
        {
            return optionDAO.Select(id);
        }
        public List<Option> Get()
        {
            return optionDAO.Select();
        }
        public List<Option>GetByProductID(string id)
        {
            return optionDAO.SelectOptionByProductID(id);   
        }
        public Option Add(Option option) { 
            return optionDAO.Insert(option);    
        }
        public bool Delete(string id) {
            return optionDAO.Delete(id);
        }
        public Option Update(Option option) { 
            return optionDAO.Update(option);
        }
    }
}
