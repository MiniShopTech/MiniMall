using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;

namespace MiniMall.DALs.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order, ApplicationDbContext, ApplicationUser>
    {
    }
}
