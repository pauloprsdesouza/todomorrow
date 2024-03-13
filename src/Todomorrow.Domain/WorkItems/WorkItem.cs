using System;
using System.Collections.Generic;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Epics;

namespace Todomorrow.Domain.WorkItems
{
    public class WorkItem : BaseModel
    {
        public Guid EpicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Epic Epic { get; set; }

        public List<ActionItem> ActionItems { get; set; } = new();
    }
}
