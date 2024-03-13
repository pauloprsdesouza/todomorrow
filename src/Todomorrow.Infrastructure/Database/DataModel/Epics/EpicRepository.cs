using Todomorrow.Domain.Epics;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Epics
{
    public class EpicRepository : BaseRepository<Epic>, IEpicRepository
    {
        public EpicRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
