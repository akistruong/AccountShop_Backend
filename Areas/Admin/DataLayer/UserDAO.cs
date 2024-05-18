using AccountShop.Helper;
using AccountShop.Models;

namespace AccountShop.Areas.Admin.DataLayer
{
    public class UserDAO
    {
        AccountShopContext context = DatabaseInstance.GetInstance();
        public List<Models.TblUser> Select()
        { 
            return context.TblUsers.ToList();   
        }
        public Models.TblUser Select(string id)
        {
            return context.TblUsers.Find(id)?? new TblUser();   
        }
        public Models.TblUser Insert(Models.TblUser user) { 
            context.TblUsers.Add(user); 
            context.SaveChanges();  
            return user;
        }
        public Models.TblUser Update(Models.TblUser user) { 
            context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
            }
        public bool Delete(string username)
        {
            var user = context.TblUsers.Find(username);
            if(user == null)
            {
                return false;
            }
            context.TblUsers.Remove(user);
            context.SaveChanges();
            return true;
        }

    }
}
