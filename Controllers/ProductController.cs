using AccountShop.Abtractions.Services.ProductService;
using AccountShop.Const;
using AccountShop.Entities;
using AccountShop.Shared.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AccountShop.Controllers
{
    [Route(Routes.PREFIX+Routes.PRODUCT)]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> result = _productService.GetAll(null);
            return Ok(result);
        }

        [HttpGet(Routes.GET_BY_ID)]
        public async Task<IActionResult> GetByID(string id)
        {
            Product result = await _productService.FindAsync(id);
            return Ok(result);
            // Code here
        }

        [HttpPost]
        public async Task<IActionResult> InsertProductAsync(ProductInsertRequestDto request)
        {
            Product _product = _mapper.Map<Product>(request);
            await _productService.Insert(_product);
            return Ok();
        }
    }
}