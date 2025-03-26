using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Responses
{
    public class CategoryResponse : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPresent { get; set; }

        public List<ProductResponse>? Products { get; set; }
    }
}
