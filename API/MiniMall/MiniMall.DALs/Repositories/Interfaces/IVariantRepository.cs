using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;

namespace MiniMall.DALs.Repositories.Interfaces
{
    public interface IVariantRepository : IGenericRepository<Variant, ApplicationDbContext, ApplicationUser>
    {
    }
}
