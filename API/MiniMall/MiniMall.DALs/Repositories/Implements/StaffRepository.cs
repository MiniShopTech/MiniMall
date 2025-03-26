using Maynghien.Infrastructure.Repository;
using MiniMall.DALs.Data;
using MiniMall.DALs.Entities;
using MiniMall.DALs.Repositories.Interfaces;

namespace MiniMall.DALs.Repositories.Implements
{
    public class StaffRepository : GenericRepository<Staff, ApplicationDbContext, ApplicationUser>, IStaffRepository
    {
        public StaffRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
