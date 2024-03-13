using System;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Users;

namespace Todomorrow.Domain.UserFollowers
{
    public class UserFollower : BaseModel
    {
        public Guid FolloweeId { get; set; }
        public Guid FollowerId { get; set; }
        public User Followee { get; set; }
        public User Follower { get; set; }
    }
}
