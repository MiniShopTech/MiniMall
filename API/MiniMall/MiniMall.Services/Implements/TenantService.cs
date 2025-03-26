using AutoMapper;
using LinqKit;
using MayNghien.Infrastructure.Helpers;
using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using Microsoft.AspNetCore.Http;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;
using MiniMall.Models.DTOs;
using MiniMall.Services.Interfaces;
using static Maynghien.Infrastructure.Helpers.SearchHelper;

namespace MiniMall.Services.Implements
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantService(ITenantRepository tenantRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _tenantRepository = tenantRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public AppResponse<TenantDTO> GetById(Guid id)
        {
            var result = new AppResponse<TenantDTO>();
            try
            {
                var userRoles = ClaimHelper.GetClaimByName(_httpContextAccessor, "Roles");
                var tenantIdClaim = ClaimHelper.GetClaimByName(_httpContextAccessor, "TenantId");
                if (userRoles.Contains("SuperAdmin"))
                    return result.BuildError("SuperAdmin does not have permission to view Tenant data");
                if (string.IsNullOrEmpty(tenantIdClaim) || !Guid.TryParse(tenantIdClaim, out var currentTenantId))
                    return result.BuildError("TenantId is not valid");
                if (id != currentTenantId)
                    return result.BuildError("You do not have permission to view this Tenant");

                var tenant = _tenantRepository.Get(id);
                var data = _mapper.Map<TenantDTO>(tenant);
                if (tenant == null || tenant.IsDeleted)
                    return result.BuildError("Tenant not found or has been deleted");
                result.BuildResult(data);
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public AppResponse<TenantDTO> Update(TenantDTO request)
        {
            var result = new AppResponse<TenantDTO>();
            try
            {
                var user = _httpContextAccessor.HttpContext!.User.Identity!.Name;
                var tenant = _tenantRepository.Get(request.Id!.Value);
                if (tenant == null)
                    return result.BuildError("Tenant not found or has been deleted");

                tenant.Name = request.Name;
                tenant.Email = request.Email;
                tenant.PhoneNumber = request.PhoneNumber;
                tenant.Type = request.Type;
                tenant.Modifiedby = user;
                tenant.ModifiedOn = DateTime.UtcNow;
                _tenantRepository.Edit(tenant);
                result.BuildResult(request);
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public AppResponse<string> Delete(Guid id)
        {
            var result = new AppResponse<string>();
            try
            {
                var user = _httpContextAccessor.HttpContext!.User.Identity!.Name;
                var tenant = _tenantRepository.Get(id);
                if (tenant == null)
                    return result.BuildError("Tenant not found or has been deleted");

                tenant.IsDeleted = true;
                _tenantRepository.Edit(tenant);
                result.BuildResult("Delete Tenant successfully");
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public AppResponse<SearchResponse<TenantDTO>> Search(SearchRequest request)
        {
            var result = new AppResponse<SearchResponse<TenantDTO>>();
            try
            {
                var userRoles = ClaimHelper.GetClaimByName(_httpContextAccessor, "Roles");
                var tenantIdClaim = ClaimHelper.GetClaimByName(_httpContextAccessor, "TenantId");
                if (userRoles.Contains("SuperAdmin") && string.IsNullOrEmpty(tenantIdClaim))
                    return result.BuildError("SuperAdmin does not have a valid TenantId");

                var currentTenantId = Guid.Parse(tenantIdClaim);
                var query = BuildFilterExpression(request.Filters!)
                            .And(c => c.IsDeleted == false)
                            .And(x => x.Id == currentTenantId);
                var numOfRecords = _tenantRepository.CountRecordsByPredicate(query);
                var users = _tenantRepository.FindByPredicate(query);
                if (request.SortBy != null)
                    users = _tenantRepository.addSort(users, request.SortBy);
                else
                    users = users.OrderBy(x => x.Name);

                int pageIndex = request.PageIndex ?? 1;
                int pageSize = request.PageSize ?? 1;
                int startIndex = (pageIndex - 1) * (int)pageSize;
                var userList = users.Skip(startIndex).Take(pageSize);
                var dtoList = userList.Select(x => _mapper.Map<TenantDTO>(x)).ToList();

                var searchResponse = new SearchResponse<TenantDTO>
                {
                    Data = dtoList,
                    CurrentPage = pageIndex,
                    TotalRows = numOfRecords,
                    TotalPages = CalculateNumOfPages(numOfRecords, pageSize),
                };
                result.Data = searchResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        private ExpressionStarter<Tenant> BuildFilterExpression(List<Filter> Filters)
        {
            try
            {
                var predicate = PredicateBuilder.New<Tenant>(true);
                if (Filters != null)
                {
                    foreach (var filter in Filters)
                    {
                        switch (filter.FieldName)
                        {
                            case "name":
                                predicate = predicate.And(m => m.Name.Contains(filter.Value));
                                break;
                            case "type":
                                {
                                    var enumN = int.Parse(filter.Value);
                                    var emunType = (Commons.Enums.TenantTypes)enumN;
                                    predicate = predicate.And(m => m.Type.Equals(emunType));
                                    break;
                                }
                            default: break;
                        }
                    }
                }

                predicate = predicate.And(x => x.IsDeleted == false);
                return predicate;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
