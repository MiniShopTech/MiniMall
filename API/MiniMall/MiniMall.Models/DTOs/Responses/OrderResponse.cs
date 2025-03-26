using MiniMall.Commons.Enums;
using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Responses
{
    public class OrderResponse : BaseDto
    {
        public double TotalAmount { get; set; }
        public Status Status { get; set; }
        public Address ProductAddress { get; set; }
        public string ShippingAddress { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public double ShippingFee { get; set; }
        
        public List<OrderDetailResponse>? OrderDetails { get; set; }
    }
}
