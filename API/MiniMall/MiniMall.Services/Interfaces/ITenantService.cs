using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs;

namespace MiniMall.Services.Interfaces
{
    public interface ITenantService
    {
        AppResponse<TenantDTO> GetById(Guid id);
        AppResponse<TenantDTO> Update(TenantDTO request);
        AppResponse<string> Delete(Guid id);
        AppResponse<SearchResponse<TenantDTO>> Search(SearchRequest request); 
    }
}
