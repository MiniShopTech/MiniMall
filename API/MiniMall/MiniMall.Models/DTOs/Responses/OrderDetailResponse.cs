using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Responses
{
    public class OrderDetailResponse : BaseDto
    {
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
