using System;
using Todomorrow.Contracts.Organizations;

namespace Todomorrow.Contracts.Projects
{
    public class ProjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public OrganizationResponse Organization { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
