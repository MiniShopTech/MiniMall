using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;

namespace MiniMall.DALs.Repositories.Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review, ApplicationDbContext, ApplicationUser>
    {
    }
}
