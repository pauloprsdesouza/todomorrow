using System;
using System.Collections.Generic;
using Todomorrow.Domain.SoftSkills;

namespace Todomorrow.Contracts.Users
{
    public class UserResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public List<SoftSkill> SoftSkills { get; set; }
        public Guid? OrganizationId { get; set; }
        public List<UserResponse> Followers { get; set; } = new();
        public List<UserResponse> Followees { get; set; } = new();
    }
}
