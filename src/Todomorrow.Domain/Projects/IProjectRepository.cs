using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.BaseModels;

namespace Todomorrow.Domain.Projects
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project> GetByIdIncludingOrganization(Guid projectId);
        Task<List<Project>> GetAllIdIncludingOrganization();
    }
}
