using System;
using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Projects;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Domain.Epics
{
    public class Epic : BaseModel
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<WorkItem> WorkItems { get; set; } = new();
        public Project Project { get; set; }
    }
}
