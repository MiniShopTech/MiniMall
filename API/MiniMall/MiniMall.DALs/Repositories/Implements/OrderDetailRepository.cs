using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class OrderDetailRepository : GenericRepository<OrderDetail, ApplicationDbContext, ApplicationUser>, IOrderDetailRepository
    {
        public OrderDetailRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
