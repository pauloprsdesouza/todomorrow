using Todomorrow.Domain.WorkItems;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.WorkItems
{
    public class WorkItemRepository : BaseRepository<WorkItem>, IWorkItemRepository
    {
        public WorkItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
