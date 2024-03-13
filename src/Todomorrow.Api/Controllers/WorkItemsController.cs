using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.Projects;
using Todomorrow.Contracts.WorkItems;
using Todomorrow.Domain.WorkItems;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/work-items")]
    [Authorize]
    public class WorkItemsController : Controller
    {
        private readonly IWorkItemService _workItemService;
        private readonly IMapper _mapper;

        public WorkItemsController(IWorkItemService workItemService, IMapper mapper)
        {
            _workItemService = workItemService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new work item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateWorkItemRequest request)
        {
            WorkItem workItem = _mapper.Map<WorkItem>(request);
            workItem = await _workItemService.Create(workItem);

            return Created($"api/v1/work-items/{workItem.Id}", workItem is not null ? _mapper.Map<WorkItemResponse>(workItem) : null);
        }

        /// <summary>
        /// Get all work items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<WorkItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            List<WorkItem> workItems = await _workItemService.GetAll();

            return Ok(_mapper.Map<List<WorkItemResponse>>(workItems));
        }
    }
}
