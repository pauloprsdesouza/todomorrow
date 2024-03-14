using System;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Projects
{
    public interface IProjectService
    {
        Task<Project> Create(Project project);
        Task<Project> Update(Project project);
        Task<Project> GetById(Guid projectId);
    }
}
