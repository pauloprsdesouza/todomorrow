using Microsoft.Extensions.DependencyInjection;
using Todomorrow.Domain.ActionItems;
using Todomorrow.Domain.Categories;
using Todomorrow.Domain.Epics;
using Todomorrow.Domain.Organizations;
using Todomorrow.Domain.Partners;
using Todomorrow.Domain.Projects;
using Todomorrow.Domain.SoftSkills;
using Todomorrow.Domain.Subcategories;
using Todomorrow.Domain.Users;
using Todomorrow.Domain.UserSkills;
using Todomorrow.Domain.WorkItems;
using Todomorrow.Infrastructure.Database.DataModel.ActionItems;
using Todomorrow.Infrastructure.Database.DataModel.Categories;
using Todomorrow.Infrastructure.Database.DataModel.Epics;
using Todomorrow.Infrastructure.Database.DataModel.Organizations;
using Todomorrow.Infrastructure.Database.DataModel.Partners;
using Todomorrow.Infrastructure.Database.DataModel.Projects;
using Todomorrow.Infrastructure.Database.DataModel.SoftSkills;
using Todomorrow.Infrastructure.Database.DataModel.Subcategories;
using Todomorrow.Infrastructure.Database.DataModel.Users;
using Todomorrow.Infrastructure.Database.DataModel.UserSkills;
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
            _ = services.AddScoped<ICategoryRepository, CategoryRepository>();
            _ = services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            _ = services.AddScoped<ISoftSkillRepository, SoftSkillRepository>();
            _ = services.AddScoped<IUserSkillRepository, UserSkillRepository>();
        }
    }
}
