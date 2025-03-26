﻿using MayNghien.Infrastructure.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniMall.DALs.Entities
{
    public class Variant : BaseEntity
    {
        public string? Type { get; set; }
        public double Price { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        public ICollection<Cart>? Carts { get; set; }
    }
}
