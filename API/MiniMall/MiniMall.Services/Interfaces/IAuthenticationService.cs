using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs;
using MiniMall.Models.DTOs.Auth.Requests;
using MiniMall.Models.DTOs.Auth.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AppResponse<LogInResponse>> LogInUser(LogInRequest request);
        Task<AppResponse<UserDTO>> GetInforAccount();
        Task<AppResponse<SignUpResponse>> SignUpUser(SignUpRequest request);
    }
}
