using System;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Users
{
    public interface IUserService
    {
        Task<UserRole> SignIn(User user, string token);
        Task<User> SignUp(User user);
        Task<User> Update(User user);
        Task<User> Follow(string loggedUser, Guid userIdToFollow);
        Task<User> Unfollow(string loggedUser, Guid userIdToFollow);
        Task<User> GetById(Guid userId);
    }
}
