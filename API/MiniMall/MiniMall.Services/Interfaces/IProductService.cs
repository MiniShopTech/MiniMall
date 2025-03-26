using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface IProductService
    {
        AppResponse<ProductResponse> GetById(Guid id);
        Task<AppResponse<ProductResponse>> Create(ProductRequest request);
        AppResponse<ProductResponse> Update(ProductRequest request);
        AppResponse<string> Delete(Guid id);
        AppResponse<SearchResponse<ProductResponse>> Search(SearchRequest request);
    }
}
