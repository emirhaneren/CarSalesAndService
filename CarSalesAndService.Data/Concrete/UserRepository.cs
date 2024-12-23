using CarSalesAndService.Data.Abstract;
using CarSalesAndService.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarSalesAndService.Data.Concrete
{
    public class UserRepository : Repository<Kullanici>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<Kullanici>> GetCustomUserList()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Rol).ToListAsync();
        }

        public async Task<List<Kullanici>> GetCustomUserList(Expression<Func<Kullanici, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Rol).ToListAsync();
        }
    }
}
