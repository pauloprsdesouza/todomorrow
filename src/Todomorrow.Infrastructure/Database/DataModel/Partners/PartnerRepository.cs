using Todomorrow.Domain.Partners;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Partners
{
    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
