using Todomorrow.Domain.SoftSkills;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.SoftSkills
{
    public class SoftSkillRepository : BaseRepository<SoftSkill>, ISoftSkillRepository
    {
        public SoftSkillRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
