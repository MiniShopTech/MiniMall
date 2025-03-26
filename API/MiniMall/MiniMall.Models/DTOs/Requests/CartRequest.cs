using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Requests
{
    public class CartRequest : BaseDto
    {
        public int Quantity { get; set; }
        public string Type { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? VariantId { get; set; }
    }
}
