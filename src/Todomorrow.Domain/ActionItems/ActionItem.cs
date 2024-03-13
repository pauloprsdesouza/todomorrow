using System;
using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Domain.ActionItems
{
    public class ActionItem : BaseModel
    {
        public Guid WorkItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public DateTimeOffset? StartedAt { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }

        public WorkItem WorkItem { get; set; }
        public List<SoftSkill> RequiredSoftSkills { get; set; } = new();
    }
}
