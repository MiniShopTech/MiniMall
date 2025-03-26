using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMall.Models.DTOs.Auth.Requests;
using MiniMall.Services.Interfaces;

namespace MiniMall.API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(LogInRequest logIn)
        {
            var result = await _authenticationService.LogInUser(logIn);
            return Ok(result);
        }

        [HttpGet]
        [Route("account-infor")]
        public async Task<IActionResult> GetAccountInfor()
        {
            var result = await _authenticationService.GetInforAccount();
            return Ok(result);  
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp(SignUpRequest signUp)
        {
            var result = await _authenticationService.SignUpUser(signUp);
            return Ok(result);
        }
    }
}
