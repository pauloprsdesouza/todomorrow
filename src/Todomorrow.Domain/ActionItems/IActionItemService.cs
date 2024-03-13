using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.ActionItems
{
    public interface IActionItemService
    {
        Task<ActionItem> Create(ActionItem actionItem);
        Task<ActionItem> Update(ActionItem actionItem);
        Task<ActionItem> GetById(Guid actionItemId);
        Task<List<ActionItem>> GetAll();
    }
}
