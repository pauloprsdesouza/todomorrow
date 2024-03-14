using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Projects;
using Todomorrow.Infrastructure.Database.DataModel.BaseModels;

namespace Todomorrow.Infrastructure.Database.DataModel.Projects
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Project>> GetAllIdIncludingOrganization()
        {
            return await _database.Include(x => x.Organization).ToListAsync();
        }

        public async Task<Project> GetByIdIncludingOrganization(Guid projectId)
        {
            return await _database.Include(x => x.Organization).SingleOrDefaultAsync(x => x.Id.Equals(projectId));
        }
    }
}
