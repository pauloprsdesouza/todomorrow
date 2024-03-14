using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Api.Authorization;
using Todomorrow.Contracts.UserSkills;
using Todomorrow.Domain.UserSkills;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/user-skills")]
    public class UserSkillsController : Controller
    {
        private readonly IUserSkillService _userSkillService;
        private readonly IMapper _mapper;

        public UserSkillsController(IUserSkillService userSkillService, IMapper mapper)
        {
            _userSkillService = userSkillService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new user skill
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserSkillResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateUserSkillRequest request)
        {
            UserSkill userSkill = _mapper.Map<UserSkill>(request);
            userSkill.UserId = User.GetId();

            userSkill = await _userSkillService.Create(userSkill);

            return Created($"api/v1/user-skills/{userSkill.Id}", userSkill is not null ? _mapper.Map<UserSkillResponse>(userSkill) : null);
        }

        /// <summary>
        /// Update a registered user skill
        /// </summary>
        /// <returns></returns>
        [HttpPut, Route("{userSkillId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(UserSkillResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid userSkillId, [FromBody] UpdateUserSkillRequest request)
        {
            UserSkill userSkill = _mapper.Map<UserSkill>(request);
            userSkill.Id = userSkillId;
            userSkill.UserId = User.GetId();

            userSkill = await _userSkillService.Update(userSkill);

            return Ok(userSkill is not null ? _mapper.Map<UserSkillResponse>(userSkill) : null);
        }

        /// <summary>
        /// Get all user skills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<UserSkillResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<UserSkill> userSkills = await _userSkillService.GetAllByLoggedUser(User.GetId());

            return Ok(_mapper.Map<IEnumerable<UserSkillResponse>>(userSkills));
        }
    }
}
