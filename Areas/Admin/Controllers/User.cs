using AccountShop.Areas.Admin.Business_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        UserBUS UserBUS;
        public User() {
            UserBUS = new UserBUS();    
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = UserBUS.Select();
                return Ok(users);
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            try
            {
                var user = UserBUS.Select(id);
                return Ok(user);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] Models.TblUser user)
        {
            try
            {
                var result = UserBUS.Insert(user);
                return Ok(result);
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }
        [HttpPut]
        public IActionResult Put([FromBody] Models.TblUser user) {
            try
            {
                var result = UserBUS.Update(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = UserBUS.Delete(id);
                return result == true ? Ok(result) : NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
