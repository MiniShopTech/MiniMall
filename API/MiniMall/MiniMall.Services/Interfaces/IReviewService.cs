using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;

namespace MiniMall.Services.Interfaces
{
    public interface IReviewService
    {
        Task<AppResponse<ReviewResponse>> Create(ReviewRequest request);
        AppResponse<SearchResponse<ReviewResponse>> Search(SearchRequest request);
    }
}
