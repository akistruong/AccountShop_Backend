using AccountShop.Areas.Admin.Controllers;
using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Helper.Interfaces;

namespace AccountShop.Helper.Context
{
    public class LoginMethodFactory
    {
        string method;
        public LoginMethodFactory(string method) {
                    this.method = method;   
        }
        public  ILoginMethod createMethod(UserDAO _userDAO)
        {
            ILoginMethod method = null;
            switch (this.method)
            {
                case "Google":
                    method = new GoogleLogin(_userDAO);
                    break;
                case "Phone":
                    method = new PhoneLogin(_userDAO);
                    break;
                default:
                    method = new DefaultLogin(_userDAO);
                    break;
            }
            return method;
        }
    }
}
