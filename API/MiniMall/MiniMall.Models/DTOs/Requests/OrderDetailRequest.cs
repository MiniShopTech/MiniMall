using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Requests
{
    public class OrderDetailRequest : BaseDto
    {
        public int Quantity { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
    }
}
