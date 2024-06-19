using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        AuthenticationBUS AuthenticationBUS;
        public Authentication(AccountShopContext context,IHttpContextAccessor httpContextAccessor)
        {
            AuthenticationBUS = new AuthenticationBUS(context, httpContextAccessor);    
        }
        [HttpGet]
        [Authorize]
        
        public IActionResult User()
        {
            var user = AuthenticationBUS.GetUser();
            return Ok(user);
        }
        [HttpPost("login")]
        public IActionResult Login(TblUser user)
        {
          var result =  AuthenticationBUS.Login(user);  
            return Ok(result);
        }
        [HttpPost("register")]
        public IActionResult Register(TblUser user)
        {
            var result = AuthenticationBUS.Register(user);
            return Ok(result);
        }
    }
}
