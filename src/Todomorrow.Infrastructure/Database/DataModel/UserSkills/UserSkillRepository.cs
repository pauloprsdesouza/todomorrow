using Todomorrow.Domain.UserSkills;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.UserSkills
{
    public class UserSkillRepository : BaseRepository<UserSkill>, IUserSkillRepository
    {
        public UserSkillRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
