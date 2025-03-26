using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class TenantRepository : GenericRepository<Tenant, ApplicationDbContext, ApplicationUser>, ITenantRepository
    {
        public TenantRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
