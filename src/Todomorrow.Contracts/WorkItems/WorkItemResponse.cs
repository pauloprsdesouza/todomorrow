using System;

namespace Todomorrow.Contracts.WorkItems
{
    public class WorkItemResponse
    {
        public Guid EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
