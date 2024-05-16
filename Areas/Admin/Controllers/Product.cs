﻿using AccountShop.Areas.Admin.Business_Layer;
using AccountShop.Helper;
using AccountShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Areas.Admin.Controllers
{
    [ApiController]
    [Area("Admin")]
    [Route("api/[area]/[controller]")]
    public class Product : ControllerBase
    {
        ProductBUS _productBUS;
        public Product() {
            _productBUS = new ProductBUS(); 
        }
        [HttpGet]
        public IActionResult Index()
        {

            var products = _productBUS.GetAllProducts();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult Post(Models.Product product)
        {
            try
            {
                var result = _productBUS.InsertProduct(product);
                return result != null ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult Put(Models.Product product)
        {
            try
            {
                var result = _productBUS.PutProduct(product);
                return result != null ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
               var result =await  _productBUS.DeleteProduct(id);
                return result == true ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
