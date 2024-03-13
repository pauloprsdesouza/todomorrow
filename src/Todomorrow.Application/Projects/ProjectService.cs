using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.Projects;

namespace Todomorrow.Application.Projects
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly INotificationContext _notificationContext;

        public ProjectService(IProjectRepository projectRepository, INotificationContext notificationContext)
        {
            _projectRepository = projectRepository;
            _notificationContext = notificationContext;
        }

        public async Task<Project> Create(Project project)
        {
            return await _projectRepository.Create(project);
        }

        public async Task<List<Project>> GetAll()
        {
            return await _projectRepository.GetAllIdIncludingOrganization();
        }

        public async Task<Project> GetById(Guid projectId)
        {
            Project project = await ValidateProject(projectId);
            if (project is null)
            {
                return null;
            }

            return project;
        }

        private async Task<Project> ValidateProject(Guid projectId)
        {
            Project project = await _projectRepository.GetByIdIncludingOrganization(projectId);
            if (project is null)
            {
                _notificationContext.AddValidationError(ProjectError.PROJECT_NOT_FOUND);
                return null;
            }

            return project;
        }

        public async Task<Project> Update(Project project)
        {
            Project projectRegistered = await ValidateProject(project.Id);
            if (projectRegistered is null)
            {
                return null;
            }

            return await _projectRepository.Update(project);
        }
    }
}
