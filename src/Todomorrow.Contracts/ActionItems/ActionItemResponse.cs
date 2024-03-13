using System;

namespace Todomorrow.Contracts.ActionItems
{
    public class ActionItemResponse
    {
        public Guid WorkItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset? StartedAt { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
