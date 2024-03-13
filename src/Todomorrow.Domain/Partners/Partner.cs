using System;
using Todomorrow.Domain.BaseModels;
using Todomorrow.Domain.Organizations;
using Todomorrow.Domain.Users;

namespace Todomorrow.Domain.Partners
{
    public class Partner : BaseModel
    {
        public Guid OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public bool IsOwner { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual User User { get; set; }
    }
}
