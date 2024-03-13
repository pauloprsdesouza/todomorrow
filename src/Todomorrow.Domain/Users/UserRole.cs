using System.Collections.Generic;

namespace Todomorrow.Domain.Users
{
    public class UserRole
    {
        public User User { get; }
        public List<string> Roles { get; } = new List<string>();

        public UserRole(User user, List<string> roles)
        {
            User = user;
            Roles = roles;
        }
    }
}
