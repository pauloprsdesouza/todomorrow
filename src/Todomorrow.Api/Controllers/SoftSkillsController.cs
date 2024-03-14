using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.SoftSkills;
using Todomorrow.Domain.SoftSkills;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/soft-skills")]
    [Authorize]
    public class SoftSkillsController : Controller
    {
        private readonly ISoftSkillService _softSkillService;
        private readonly IMapper _mapper;

        public SoftSkillsController(ISoftSkillService softSkillService, IMapper mapper)
        {
            _softSkillService = softSkillService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new soft skill
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SoftSkillResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateSoftSkillRequest request)
        {
            SoftSkill softSkill = _mapper.Map<SoftSkill>(request);
            softSkill = await _softSkillService.Create(softSkill);

            return Created($"api/v1/soft-skills/{softSkill.Id}", softSkill is not null ? _mapper.Map<SoftSkillResponse>(softSkill) : null);
        }

        /// <summary>
        /// Get all soft skills for a subcategory
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{subcategoryId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<SoftSkillResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromRoute] Guid softSkillId)
        {
            IEnumerable<SoftSkill> softSkills = await _softSkillService.GetAllBySubcategoryId(softSkillId);

            return Ok(_mapper.Map<IEnumerable<SoftSkillResponse>>(softSkills));
        }
    }
}
    