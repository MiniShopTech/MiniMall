﻿using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Responses
{
    public class StaffResponse : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
