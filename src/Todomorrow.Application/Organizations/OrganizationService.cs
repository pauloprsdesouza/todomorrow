using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todomorrow.Domain.Organizations;

namespace Todomorrow.Application.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<Organization> Create(Organization organization)
        {
            return await _organizationRepository.Create(organization);
        }

        public async Task<IEnumerable<Organization>> GetAll()
        {
            return await _organizationRepository.GetAll();
        }

        private async Task<Organization> ValidateOrganizationById(Guid organizationId)
        {
            Organization organization = await _organizationRepository.GetById(organizationId);
            if (organization is null)
            {
                return null;
            }

            return organization;
        }

        public async Task<Organization> GetById(Guid organizationId)
        {
            Organization organization = await ValidateOrganizationById(organizationId);
            if (organization is null)
            {
                return null;
            }

            return organization;
        }

        public async Task<Organization> Update(Organization organization)
        {
            Organization organizationRegistered = await ValidateOrganizationById(organization.Id);
            if (organization is null)
            {
                return null;
            }

            organizationRegistered.Name = organization.Name;

            return await _organizationRepository.Update(organization);
        }
    }
}
