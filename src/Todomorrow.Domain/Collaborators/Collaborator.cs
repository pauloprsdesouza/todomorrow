using System;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Organizations;
using Todomorrow.Domain.Users;

namespace Todomorrow.Domain.Collaborators
{
    public class Collaborator : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid? OrganizationId { get; set; }
        public DateTimeOffset AdmissionDate { get; set; }
        public DateTimeOffset? ResignationDate { get; set; }

        public User User { get; set; }
        public Organization Organization { get; set; } = null;
    }
}
