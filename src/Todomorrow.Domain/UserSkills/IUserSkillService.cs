using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.UserSkills
{
    public interface IUserSkillService
    {
        Task<UserSkill> Create(UserSkill userSkill);
        Task<UserSkill> Update(UserSkill userSkill);
        Task<UserSkill> GetById(Guid userSkillId);
        Task<IEnumerable<UserSkill>> GetAllByLoggedUser(Guid userId);
    }
}
