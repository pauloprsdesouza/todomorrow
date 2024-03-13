using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Api.Authorization;
using Todomorrow.Contracts.Organizations;
using Todomorrow.Domain.Organizations;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/organizations")]
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;

        public OrganizationsController(IOrganizationService organizationService, IMapper mapper)
        {
            _organizationService = organizationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new organization
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(OrganizationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationRequest request)
        {
            Organization organization = _mapper.Map<Organization>(request);
            organization.AddPartner(User.GetId());

            await _organizationService.Create(organization);

            return Ok(organization is not null ? _mapper.Map<OrganizationResponse>(organization) : null);
        }

        /// <summary>
        /// List all registered organizations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<OrganizationResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<Organization> response = await _organizationService.GetAll();

            return Ok(response is not null ? _mapper.Map<List<OrganizationResponse>>(response) : null);
        }
    }
}
