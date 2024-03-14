using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.Notifications;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Application.ActionItems
{
    public class ActionItemService : IActionItemService
    {
        private readonly IActionItemRepository _actionItemRepository;
        private readonly INotificationContext _notificationContext;
        private readonly IWorkItemRepository _workItemRepository;

        public ActionItemService(IActionItemRepository actionItemRepository, INotificationContext notificationContext, IWorkItemRepository workItemRepository)
        {
            _actionItemRepository = actionItemRepository;
            _notificationContext = notificationContext;
            _workItemRepository = workItemRepository;
        }

        public async Task<ActionItem> Create(ActionItem actionItem)
        {
            WorkItem workItem = await _workItemRepository.GetById(actionItem.WorkItemId);
            if (workItem is null)
            {
                _notificationContext.AddValidationError(WorkItemError.WORK_ITEM_NOT_FOUND);
                return null;
            }

            return await _actionItemRepository.Create(actionItem);
        }

        private async Task<ActionItem> ValidateActionItemById(Guid actionId)
        {
            ActionItem actionItem = await _actionItemRepository.GetById(actionId);
            if (actionItem is null)
            {
                _notificationContext.AddValidationError(ActionItemError.ACTION_ITEM_NOT_FOUND);
                return null;
            }

            return actionItem;
        }

        public Task<IEnumerable<ActionItem>> GetAll()
        {
            return _actionItemRepository.GetAll();
        }

        public async Task<ActionItem> GetById(Guid actionItemId)
        {
            ActionItem actionItem = await ValidateActionItemById(actionItemId);
            if (actionItem is null)
            {
                return null;
            }

            return actionItem;
        }

        public async Task<ActionItem> Update(ActionItem actionItem)
        {
            ActionItem actionItemRegistered = await ValidateActionItemById(actionItem.Id);
            if (actionItem is null)
            {
                return null;
            }

            actionItemRegistered.DueDate = actionItem.DueDate;
            actionItemRegistered.Description = actionItem.Description;
            actionItemRegistered.StartedAt = actionItem.StartedAt;
            actionItemRegistered.CompletedAt = actionItem.CompletedAt;

            return await _actionItemRepository.Update(actionItem);
        }
    }
}
