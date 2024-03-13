using System.Threading.Tasks;
using Todomorrow.Domain.BaseModels;

namespace Todomorrow.Domain.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetProfile(string email);
    }
}
