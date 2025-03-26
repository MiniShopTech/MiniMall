using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class OrderRepository : GenericRepository<Order, ApplicationDbContext, ApplicationUser>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
