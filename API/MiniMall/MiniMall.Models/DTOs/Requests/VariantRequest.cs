using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Requests
{
    public class VariantRequest : BaseDto
    {
        public string? Type { get; set; }
        public double Price { get; set; }
        public Guid? ProductId { get; set; }
    }
}
