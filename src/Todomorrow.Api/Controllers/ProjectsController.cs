using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(List<ProjectResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            List<Project> projects = await _projectService.GetAll();

            return Ok(_mapper.Map<List<ProjectResponse>>(projects));
        }
    }
}
