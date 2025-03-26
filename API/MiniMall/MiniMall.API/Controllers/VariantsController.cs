using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Services.Implements;

namespace EasyMall.API.Controllers
{
    [Route("variant")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, TenantAdmin")]
    public class VariantsController : ControllerBase
    {
        private readonly VariantService _variantService;

        public VariantsController(VariantService variantService)
        {
            _variantService = variantService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(VariantRequest request)
        {
            var result = await _variantService.Create(request);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(VariantRequest request)
        {
            var result = _variantService.Update(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _variantService.Delete(id);
            return Ok(result);
        }
    }
}
