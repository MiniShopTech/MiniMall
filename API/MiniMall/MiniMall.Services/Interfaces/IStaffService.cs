using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface IStaffService
    {
        AppResponse<StaffResponse> GetById(Guid id);
        Task<AppResponse<StaffResponse>> Create(StaffRequest request);
        AppResponse<StaffResponse> Update(StaffRequest request);
        AppResponse<string> Delete(Guid id);
        AppResponse<SearchResponse<StaffResponse>> Search(SearchRequest request);
    }
}
