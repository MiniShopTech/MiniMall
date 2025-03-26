using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class ProductRepository : GenericRepository<Product, ApplicationDbContext, ApplicationUser>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
