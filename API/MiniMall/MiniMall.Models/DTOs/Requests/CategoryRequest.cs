using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Requests
{
    public class CategoryRequest : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPresent { get; set; }
    }
}
