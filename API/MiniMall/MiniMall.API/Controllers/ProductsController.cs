using MayNghien.Infrastructure.Request.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Services.Interfaces;

namespace MiniMall.API.Controllers
{
    [Route("product")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, TenantAdmin")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _productService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest request)
        {
            var result = await _productService.Create(request);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(ProductRequest request)
        {
            var result = _productService.Update(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _productService.Delete(id);
            return Ok(result);
        }

        [HttpPost("search")]
        public IActionResult Search(SearchRequest request)
        {
            var result = _productService.Search(request);
            return Ok(result);
        }
    }
}
