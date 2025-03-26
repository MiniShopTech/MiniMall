using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface ICategoryService
    {
        AppResponse<List<CategoryResponse>> GetByPresent();
        AppResponse<CategoryResponse> GetById(Guid id);
        AppResponse<List<ProductResponse>> GetListProductByCategoryId(Guid categoryId);
        Task<AppResponse<CategoryResponse>> Create(CategoryRequest request);
        AppResponse<CategoryResponse> Update(CategoryRequest request);
        AppResponse<string> Delete(Guid id);
        AppResponse<SearchResponse<CategoryResponse>> Search(SearchRequest request);
    }
}
