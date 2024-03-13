using Todomorrow.Domain.Organizations;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Organizations
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
