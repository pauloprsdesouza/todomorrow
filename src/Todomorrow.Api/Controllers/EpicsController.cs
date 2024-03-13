using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.Epics;
using Todomorrow.Domain.Epics;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/epics")]
    [Authorize]
    public class EpicsController : Controller
    {
        private readonly IEpicService _epicService;
        private readonly IMapper _mapper;

        public EpicsController(IEpicService epicService, IMapper mapper)
        {
            _epicService = epicService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new epic
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EpicResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateEpicRequest request)
        {
            Epic epic = _mapper.Map<Epic>(request);
            epic = await _epicService.Create(epic);

            return Ok(epic is not null ? _mapper.Map<EpicResponse>(epic) : null);
        }

        /// <summary>
        /// Get all epics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<EpicResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            List<Epic> epics = await _epicService.GetAll();

            return Ok(_mapper.Map<List<EpicResponse>>(epics));
        }
    }
}
