using AccountShop.Areas.Admin.DataLayer;
using AccountShop.Areas.Admin.Interfaces;
using AccountShop.Dtos;
using AccountShop.Helper;
using AccountShop.Helper.Context;
using AccountShop.Helper.Interfaces;
using AccountShop.Models;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;


namespace AccountShop.Areas.Admin.Business_Layer
{
    public class AuthenticationBUS : IAuthentication
    {
        UserDAO UserDAO;
        public AuthenticationBUS(AccountShopContext context) { 
            UserDAO = new UserDAO(context);    
        }
        [Authorize]
        public TblUser GetUser(TblUser user)
        {
            JwtHelper jwt = new JwtHelper();
            return user;
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
