using Microsoft.Extensions.DependencyInjection;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.Epics;
using Todomorrow.Domain.Organizations;
using Todomorrow.Domain.Partners;
using Todomorrow.Domain.Projects;
using Todomorrow.Domain.Users;
using Todomorrow.Domain.WorkItems;
using Todomorrow.Infrastructure.Database.DataModel.ActionItems;
using Todomorrow.Infrastructure.Database.DataModel.Epics;
using Todomorrow.Infrastructure.Database.DataModel.Organizations;
using Todomorrow.Infrastructure.Database.DataModel.Partners;
using Todomorrow.Infrastructure.Database.DataModel.Projects;
using Todomorrow.Infrastructure.Database.DataModel.Users;
using Todomorrow.Infrastructure.Database.DataModel.WorkItems;

namespace Todomorrow.Api.Dependencies
{
    public static class RepositoryDependency
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            _ = services.AddScoped<IUserRepository, UserRepository>();
            _ = services.AddScoped<IEpicRepository, EpicRepository>();
            _ = services.AddScoped<IWorkItemRepository, WorkItemRepository>();
            _ = services.AddScoped<IProjectRepository, ProjectRepository>();
            _ = services.AddScoped<IActionItemRepository, ActionItemRepository>();
            _ = services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            _ = services.AddScoped<IPartnerRepository, PartnerRepository>();
            _ = services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        }
    }
}
