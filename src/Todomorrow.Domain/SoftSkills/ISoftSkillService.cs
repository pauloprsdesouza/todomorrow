using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.SoftSkills
{
    public interface ISoftSkillService
    {
        Task<SoftSkill> Create(SoftSkill softSkill);
        Task<SoftSkill> Update(SoftSkill softSkill);
        Task<IEnumerable<SoftSkill>> GetAllBySubcategoryId(Guid subcategoryId);
        Task<SoftSkill> GetById(Guid softSkillId);
    }
}
