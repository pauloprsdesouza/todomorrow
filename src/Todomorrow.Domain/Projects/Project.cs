using System;
using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Epics;
using Todomorrow.Domain.Organizations;

namespace Todomorrow.Domain.Projects
{
    public class Project : BaseModel
    {
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Organization Organization { get; set; }

        public List<Epic> Epics { get; set; }
    }
}
