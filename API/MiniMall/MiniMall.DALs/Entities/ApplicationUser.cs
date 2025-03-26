using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniMall.DALs.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Tenant")]
        public Guid? TenantId { get; set; }
        public Tenant? Tenant { get; set; }

        [ForeignKey("Staff")]
        public Guid? StaffId { get; set; }
        public Staff? Staff { get; set; }
    }
}
