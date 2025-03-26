using MayNghien.Infrastructure.Request.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Services.Interfaces;

namespace MiniMall.API.Controllers
{
    [Route("review")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, TenantAdmin")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewRequest request)
        {
            var result = await _reviewService.Create(request);
            return Ok(result);
        }

        [HttpPost("search")]
        public IActionResult Search(SearchRequest request)
        {
            var result = _reviewService.Search(request);
            return Ok(result);
        }
    }
}
