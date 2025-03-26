using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class VariantRepository : GenericRepository<Variant, ApplicationDbContext, ApplicationUser>, IVariantRepository
    {
        public VariantRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
