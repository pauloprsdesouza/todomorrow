using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Todomorrow.Domain.BaseModels;

namespace Todomorrow.Domain.SoftSkills
{
    public interface ISoftSkillRepository : IBaseRepository<SoftSkill>
    {
        Task<IEnumerable<SoftSkill>> GetAllBySubcategoryId(Guid subcategoryId);
    }
}
