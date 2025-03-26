using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface IOrderService
    {
        Task<AppResponse<OrderResponse>> Create(OrderRequest request);
    }
}
