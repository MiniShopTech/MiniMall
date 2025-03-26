using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class ReviewRepository : GenericRepository<Review, ApplicationDbContext, ApplicationUser>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
