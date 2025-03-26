using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;

namespace MiniMall.DALs.Repositories.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart, ApplicationDbContext, ApplicationUser>
    {
    }
}
