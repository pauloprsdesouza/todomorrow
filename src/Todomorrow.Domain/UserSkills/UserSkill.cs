using System;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.Users;

namespace Todomorrow.Domain.UserSkills
{
    public class UserSkill : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid SoftSkillId { get; set; }
        public int Level { get; set; }

        public virtual User User { get; set; }
        public virtual SoftSkill SoftSkill { get; set; }
    }
}
