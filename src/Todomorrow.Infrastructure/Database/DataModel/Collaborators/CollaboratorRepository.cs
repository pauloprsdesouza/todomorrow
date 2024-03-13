using Todomorrow.Domain.Collaborators;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Collaborators
{
    public class CollaboratorRepository : BaseRepository<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
