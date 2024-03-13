using System;
using System.Collections.Generic;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Collaborators;
using Todomorrow.Domain.Partners;
using Todomorrow.Domain.Projects;
using Todomorrow.Domain.Users;

namespace Todomorrow.Domain.Organizations
{
    public class Organization : BaseModel
    {
        public string Name { get; set; }

        public List<Project> Projects { get; set; } = new();
        public List<Collaborator> Collaborators { get; set; } = new();
        public List<Partner> Partners { get; set; } = new();

        public void AddPartner(Guid userId)
        {
            Partners.Add(new Partner { UserId = userId, IsOwner = true, CreatedAt = DateTimeOffset.UtcNow });
        }
    }
}
