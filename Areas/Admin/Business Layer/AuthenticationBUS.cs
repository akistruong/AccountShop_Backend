using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Helper;
using AccountShop.Helper.Context;
using AccountShop.Models;
using Microsoft.AspNetCore.Authorization;
namespace AccountShop.Areas.Admin.Business_Layer
{
    public class AuthenticationBUS : IAuthentication
    {
        UserDAO UserDAO;
        UserContext _userContext;
        public AuthenticationBUS(AccountShopContext context,IHttpContextAccessor httpContext)
        {
            UserDAO = new UserDAO(context);
            this._userContext =new UserContext(httpContext);    
        }
        [Authorize]
        public Response GetUser()
        {
            string userID = _userContext.GetNameIdentifier();
            var user = UserDAO.Select(userID);
            var userInfo = FieldHelper.GetFieldInfo(new HashSet<string> { "Username" , "Email", "TblOrders"}, user);
            var response = new Response();
            response.code = 200;
            response.message = "";
            response.metadata = userInfo;   
            return response;
        }

        public Response Login(TblUser user)
        {
            LoginMethodFactory MethodFactory = new LoginMethodFactory(user.LoginMethod??"");
            var Method = MethodFactory.createMethod(UserDAO);
            LoginContext LoginContext = new LoginContext(Method);
            return LoginContext.Login(user);
        }

        public Response Register(TblUser user)
        {
            JwtHelper jwt = new JwtHelper();
            var User = UserDAO.Select(user.Username);
            Response response = new Response();
            if (User == null)
            {
             if(user.Pwd!=null)  user.Pwd = HashHelper.Encode(user.Pwd);
                UserDAO.Insert(user);
                
                response.code = 200;
                response.message = "Register success";
                response.metadata = jwt.Generate(user.Username); response.metadata = jwt.Generate(user.Username);
                return response;
            }
            
            response.code = 500;
            response.message = "Register faild";
            response.metadata = null;
            return response;
        }

      
    }
}
