using MiniMall.Commons.Enums;
using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Requests
{
    public class StaffRequest : BaseDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
