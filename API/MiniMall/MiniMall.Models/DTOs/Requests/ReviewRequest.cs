﻿using MiniMall.Commons.Enums;
using MayNghien.Infrastructure.Models;

namespace MiniMall.Models.DTOs.Requests
{
    public class ReviewRequest : BaseDto
    {
        public Ratings Rating { get; set; }
        public string? Comment { get; set; }
        public Guid? ProductId { get; set; }
    }
}
