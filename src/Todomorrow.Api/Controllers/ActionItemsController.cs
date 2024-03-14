using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.ActionItems;
using Todomorrow.Domain.ActionItems;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/action-items")]
    [Authorize]
    public class ActionItemsController : Controller
    {
        private readonly IActionItemService _actionItemService;
        private readonly IMapper _mapper;

        public ActionItemsController(IActionItemService actionItemService, IMapper mapper)
        {
            _actionItemService = actionItemService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new action item
        /// </summary>
        /// <returns>A created action item</returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ActionItemResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateActionItemRequest request)
        {
            ActionItem actionItem = _mapper.Map<ActionItem>(request);
            actionItem = await _actionItemService.Create(actionItem);

            return Created($"api/v1/action-items/{actionItem.Id}", actionItem is not null ? _mapper.Map<ActionItemResponse>(actionItem) : null);
        }

        /// <summary>
        /// Get action item by id
        /// </summary>
        /// <returns>A registered action item</returns>
        [HttpGet, Route("{actionItemId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<ActionItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid actionItemId)
        {
            ActionItem actionItem = await _actionItemService.GetById(actionItemId);

            return Ok(actionItem is not null ? _mapper.Map<ActionItemResponse>(actionItem) : null);
        }

        /// <summary>
        /// Update a registered action item
        /// </summary>
        /// <returns>An updated action item</returns>
        [HttpPut, Route("{actionItemId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<ActionItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid actionItemId, [FromBody] UpdateActionItemRequest request)
        {
            ActionItem actionItem = _mapper.Map<ActionItem>(request);
            actionItem.Id = actionItemId;

            actionItem = await _actionItemService.Update(actionItem);

            return Ok(actionItem is not null ? _mapper.Map<ActionItemResponse>(actionItem) : null);
        }

        /// <summary>
        /// Get all action items
        /// </summary>
        /// <returns>An updated action item</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<ActionItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ActionItem> actionItems = await _actionItemService.GetAll();

            return Ok(_mapper.Map<IEnumerable<ActionItemResponse>>(actionItems));
        }
    }
}
