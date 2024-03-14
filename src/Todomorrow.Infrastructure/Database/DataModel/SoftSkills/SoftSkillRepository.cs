using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.SoftSkills
{
    public class SoftSkillRepository : BaseRepository<SoftSkill>, ISoftSkillRepository
    {
        public SoftSkillRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<SoftSkill>> GetAllBySubcategoryId(Guid subcategoryId)
        {
            return await _database.Where(x => x.SubcategoryId == subcategoryId).ToListAsync();
        }
    }
}
