using AutoMapper;
using MiniMall.DALs.Entities;
using MiniMall.Models.DTOs.Requests;
using MiniMall.Models.DTOs.Responses;
using MiniMall.Models.DTOs;

namespace MiniMall.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap();
        }

        public void CreateMap()
        {
            CreateMap<Tenant, TenantDTO>().ReverseMap();

            #region Entity - Request
            CreateMap<Category, CategoryRequest>().ReverseMap();
            CreateMap<Product, ProductRequest>().ReverseMap();
            CreateMap<Variant, VariantRequest>().ReverseMap();
            CreateMap<Cart, CartRequest>().ReverseMap();
            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailRequest>().ReverseMap();
            CreateMap<Review, ReviewRequest>().ReverseMap();
            CreateMap<Staff, StaffRequest>().ReverseMap();
            #endregion

            #region Entity - Response
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<Variant, VariantResponse>().ReverseMap();
            CreateMap<Cart, CartResponse>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailResponse>().ReverseMap();
            CreateMap<Review, ReviewResponse>().ReverseMap();
            CreateMap<Staff, StaffResponse>().ReverseMap();
            #endregion

            #region Request - Response
            CreateMap<CategoryRequest, CategoryResponse>().ReverseMap();
            CreateMap<ProductRequest, ProductResponse>().ReverseMap();
            CreateMap<VariantRequest, VariantResponse>().ReverseMap();
            CreateMap<CartRequest, CartResponse>().ReverseMap();
            CreateMap<OrderRequest, OrderResponse>().ReverseMap();
            CreateMap<OrderDetailRequest, OrderDetailResponse>().ReverseMap();
            CreateMap<ReviewRequest, ReviewResponse>().ReverseMap();
            CreateMap<StaffRequest, StaffResponse>().ReverseMap();
            #endregion
        }
    }
}
