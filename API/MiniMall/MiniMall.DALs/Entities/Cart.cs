﻿using MayNghien.Infrastructure.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniMall.DALs.Entities
{
    public class Cart : BaseEntity
    {
        public int Quantity { get; set; }
        public string Type { get; set; }
        public double TotalAmount { get; set; }

        [ForeignKey("Tenant")]
        public Guid? TenantId { get; set; }
        public Tenant? Tenant { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        [ForeignKey("Variant")]
        public Guid? VariantId { get; set; }
        public Variant? Variant { get; set; }
    }
}
