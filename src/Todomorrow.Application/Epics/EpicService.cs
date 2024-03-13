using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Epics;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.Projects;

namespace Todomorrow.Application.Epics
{
    public class EpicService : IEpicService
    {
        private readonly IEpicRepository _epicRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IProjectRepository _projectRepository;

        public EpicService(IEpicRepository epicRepository, INotificationContext notificationContext, IProjectRepository projectRepository)
        {
            _epicRepository = epicRepository;
            _notificationContext = notificationContext;
            _projectRepository = projectRepository;
        }

        public async Task<Epic> Create(Epic epic)
        {
            Project project = await _projectRepository.GetById(epic.ProjectId);
            if (project is null)
            {
                _notificationContext.AddValidationError(ProjectError.PROJECT_NOT_FOUND);
                return null;
            }

            return await _epicRepository.Create(epic);
        }

        private async Task<Epic> ValidateEpicById(Guid epicId)
        {
            Epic epic = await _epicRepository.GetById(epicId);
            if (epic is null)
            {
                _notificationContext.AddValidationError(EpicError.EPIC_NOT_FOUND);
                return null;
            }

            return epic;
        }

        public async Task<List<Epic>> GetAll()
        {
            return await _epicRepository.GetAll();
        }

        public async Task<Epic> GetById(Guid epicId)
        {
            Epic epic = await ValidateEpicById(epicId);
            if (epic is null)
            {
                return null;
            }

            return epic;
        }

        public async Task<Epic> Update(Epic epic)
        {
            Epic epicRegistered = await ValidateEpicById(epic.Id);
            if (epic is null)
            {
                return null;
            }

            epicRegistered.Name = epic.Name;
            epicRegistered.Description = epic.Description;

            return await _epicRepository.Update(epic);
        }
    }
}
