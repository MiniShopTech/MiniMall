using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface IVariantService
    {
        Task<AppResponse<VariantResponse>> Create(VariantRequest request);
        AppResponse<VariantResponse> Update(VariantRequest request);
        AppResponse<string> Delete(Guid id);
    }
}
