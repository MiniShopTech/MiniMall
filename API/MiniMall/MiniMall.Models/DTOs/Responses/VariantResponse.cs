using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Responses
{
    public class VariantResponse : BaseDto
    {
        public string? Type { get; set; }
        public double Price { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
