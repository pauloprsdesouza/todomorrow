using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Todomorrow.Domain.Organizations
{
    public interface IOrganizationService
    {
        Task<Organization> Create(Organization organization);
        Task<Organization> Update(Organization organization);
        Task<Organization> GetById(Guid organizationId);
        Task<IEnumerable<Organization>> GetAll();
    }
}
