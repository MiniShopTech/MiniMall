using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Services.Interfaces;

namespace MiniMall.API.Controllers
{
    [Route("cart")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, TenantAdmin")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartRequest request)
        {
            var result = await _cartService.AddToCart(request);
            return Ok(result);
        }

        [HttpDelete("remove")]
        public IActionResult RemoveFromCart(Guid productId)
        {
            var result = _cartService.RemoveFromCart(productId);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteFromCart(Guid productId)
        {
            var result = _cartService.DeleteFromCart(productId);
            return Ok(result);
        }
    }
}
