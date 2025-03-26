using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface ICartService
    {
        Task<AppResponse<CartResponse>> AddToCart(CartRequest request);
        AppResponse<string> RemoveFromCart(Guid productId);
        AppResponse<string> DeleteFromCart(Guid productId);
    }
}
