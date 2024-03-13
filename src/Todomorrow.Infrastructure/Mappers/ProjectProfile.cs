using AutoMapper;
using Todomorrow.Contracts.Projects;
using Todomorrow.Domain.Projects;

namespace Todomorrow.Infrastructure.Mappers
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<CreateProjectRequest, Project>();
            CreateMap<Project, ProjectResponse>();
        }
    }
}
