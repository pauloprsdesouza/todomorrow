using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Collaborators;
using Todomorrow.Domain.Partners;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.UserFollowers;

namespace Todomorrow.Domain.Users
{
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public List<SoftSkill> SoftSkills { get; set; } = new();
        public List<UserFollower> Followers { get; set; } = new();
        public List<UserFollower> Followees { get; set; } = new();
        public List<Collaborator> Organizations { get; set; } = new();
        public List<Partner> Partners { get; set; } = new();

        public void AddFollower(UserFollower follower)
        {
            if (!Followers.Contains(follower))
            {
                Followers.Add(follower);
            }
        }

        public void RemoveFollower(UserFollower follower)
        {
            if (Followers.Contains(follower))
            {
                Followers.Remove(follower);
            }
        }

        public void AddFollowee(UserFollower followee)
        {
            if (!Followees.Contains(followee))
            {
                Followees.Add(followee);
            }
        }

        public void RemoveFollowee(UserFollower followee)
        {
            if (Followees.Contains(followee))
            {
                Followees.Remove(followee);
            }
        }
    }
}
