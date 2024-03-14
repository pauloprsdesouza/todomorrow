using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.WorkItems
{
    public interface IWorkItemService
    {
        Task<WorkItem> Create(WorkItem workItem);
        Task<WorkItem> Update(WorkItem workItem);
        Task<WorkItem> GetById(Guid workItemId);
        Task<IEnumerable<WorkItem>> GetAll();
    }
}
