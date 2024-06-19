using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.Business_Layer
{
    public class UserBUS : IUser
    {
        UserDAO userDAO;
        AccountShopContext context;



        public UserBUS(AccountShopContext context)
        {
            userDAO = new UserDAO(context);
        }
        public bool Delete(string id)
        {
            return userDAO.Delete(id);  
        }

        public TblUser Insert(TblUser user)
        {
            return userDAO.Insert(user);
        }

        public List<TblUser> Select()
        {
            return userDAO.Select();
        }

        public TblUser Select(string id)
        {
            return userDAO.Select(id);  
        }

        public TblUser Update(TblUser user)
        {
            return userDAO.Update(user);    
        }
    }
}
