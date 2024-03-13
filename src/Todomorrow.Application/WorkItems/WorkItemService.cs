using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Epics;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Application.Features
{
    public class WorkItemService : IWorkItemService
    {
        private readonly IWorkItemRepository _workItemRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IEpicRepository _epicRepository;

        public WorkItemService(IWorkItemRepository workItemRepository, INotificationContext notificationContext, IEpicRepository epicRepository)
        {
            _workItemRepository = workItemRepository;
            _notificationContext = notificationContext;
            _epicRepository = epicRepository;
        }

        public async Task<WorkItem> Create(WorkItem workItem)
        {
            Epic epic = await _epicRepository.GetById(workItem.EpicId);
            if (epic is null)
            {
                _notificationContext.AddValidationError(EpicError.EPIC_NOT_FOUND);
                return null;
            }

            return await _workItemRepository.Create(workItem);
        }

        public Task<List<WorkItem>> GetAll()
        {
            return _workItemRepository.GetAll();
        }

        private async Task<WorkItem> ValidateWorkItemById(Guid workItemId)
        {
            WorkItem workItem = await _workItemRepository.GetById(workItemId);
            if (workItem is null)
            {
                _notificationContext.AddValidationError(WorkItemError.WORK_ITEM_NOT_FOUND);
                return null;
            }

            return workItem;
        }

        public async Task<WorkItem> GetById(Guid workItemId)
        {
            WorkItem workItem = await ValidateWorkItemById(workItemId);
            if (workItem is null)
            {
                return null;
            }

            return workItem;
        }

        public async Task<WorkItem> Update(WorkItem workItem)
        {
            WorkItem workItemRegistered = await ValidateWorkItemById(workItem.Id);
            if (workItem is null)
            {
                return null;
            }

            workItemRegistered.Name = workItem.Name;
            workItemRegistered.Description = workItem.Description;
            workItemRegistered.EpicId = workItem.EpicId;

            return await _workItemRepository.Update(workItemRegistered);
        }
    }
}
