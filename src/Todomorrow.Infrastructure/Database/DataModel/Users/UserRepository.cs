using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Todomorrow.Domain.Users;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetProfile(string email)
        {
            return await _database.SingleOrDefaultAsync(x => x.Email.Equals(email));
        }
    }
}
