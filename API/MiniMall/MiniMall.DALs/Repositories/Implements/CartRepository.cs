using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class CartRepository : GenericRepository<Cart, ApplicationDbContext, ApplicationUser>, ICartRepository
    {
        public CartRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
