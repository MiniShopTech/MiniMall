using MayNghien.Infrastructure.Request.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs;
using MiniMall.Services.Interfaces;

namespace MiniMall.API.Controllers
{
    [Route("tenant")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, TenantAdmin")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _tenantService.GetById(id);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(TenantDTO request)
        {
            var response = _tenantService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var response = _tenantService.Delete(id);
            return Ok(response);
        }

        [HttpPost("search")]
        public IActionResult Search(SearchRequest request)
        {
            var response = _tenantService.Search(request);
            return Ok(response);
        }
    }
}
