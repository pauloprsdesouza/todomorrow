using AutoMapper;
using Todomorrow.Contracts.Organizations;
using Todomorrow.Domain.Organizations;

namespace Todomorrow.Infrastructure.Mappers
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<CreateOrganizationRequest, Organization>();

            CreateMap<Organization, OrganizationResponse>();
        }
    }
}
