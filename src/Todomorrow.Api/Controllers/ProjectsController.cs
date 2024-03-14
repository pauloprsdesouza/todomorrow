using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Todomorrow.Contracts.Projects;
using Todomorrow.Domain.Projects;

namespace Todomorrow.Api.Controllers
{
    [Route("api/v1/projects")]
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
        {
            Project project = _mapper.Map<Project>(request);
            project = await _projectService.Create(project);

            return Created($"api/v1/projects/{project.Id}", project is not null ? _mapper.Map<ProjectResponse>(project) : null);
        }

        /// <summary>
        /// Update a registered a project
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("{projectId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute] Guid projectId, [FromBody] UpdateProjectRequest request)
        {
            Project project = _mapper.Map<Project>(request);
            project.Id = projectId;

            project = await _projectService.Create(project);

            return Ok(project is not null ? _mapper.Map<ProjectResponse>(project) : null);
        }

        /// <summary>
        /// Get a registered a project
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{projectId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid projectId)
        {
            Project project = await _projectService.GetById(projectId);

            return Ok(project is not null ? _mapper.Map<ProjectResponse>(project) : null);
        }
    }
}
