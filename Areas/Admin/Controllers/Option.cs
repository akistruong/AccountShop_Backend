using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Option : ControllerBase
    {
        OptionBUS OptionBUS;

        public Option(AccountShopContext context)
        {
            OptionBUS = new OptionBUS(context); 
        }
       
        [HttpGet("{id}")]
        public IActionResult Get(string id) { 
           var result = OptionBUS.Get(id);  
            return Ok(result);
        }
        [HttpGet]
        public IActionResult Get() { 
            var result = OptionBUS.Get();   
            return Ok(result);  
        }
        [HttpGet("GetByProduct/{productID}")]
        public IActionResult GetByProductID(string productID)
        {
            var result = OptionBUS.GetByProductID(productID);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(Models.Option option)
        {
            var result = OptionBUS.Add(option);
            return Ok(result);
        }
        [HttpPut]
        public IActionResult Put(Models.Option option) {
            var result = OptionBUS.Update(option);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var result = OptionBUS.Delete(id);
            return Ok(result);
        }
    }

}
