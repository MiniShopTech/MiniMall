using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Services.Interfaces;

namespace MiniMall.API.Controllers
{
    [Route("staff")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin, TenantAdmin")]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffsController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _staffService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StaffRequest request)
        {
            var result = await _staffService.Create(request);
            return Ok(result);
        }
    }
}
