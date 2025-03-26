using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class CategoryRepository : GenericRepository<Category, ApplicationDbContext, ApplicationUser>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
