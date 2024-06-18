using AccountShop.Helper.Interfaces;
using AccountShop.Models;

namespace AccountShop.Helper.Context
{
    public class LoginContext
    {
        ILoginMethod loginMethod;
        public LoginContext(ILoginMethod method) {
                
            this.loginMethod = method;  
        
        }
        public Response Login(TblUser user)
        {
           return loginMethod.Login(user);
        }
    }
}
