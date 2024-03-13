using Todomorrow.Domain.ActionItems;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.ActionItems
{
    public class ActionItemRepository : BaseRepository<ActionItem>, IActionItemRepository
    {
        public ActionItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
