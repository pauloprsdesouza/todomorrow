using Microsoft.Extensions.DependencyInjection;
using Todomorrow.Application.ActionItems;
using Todomorrow.Application.Categories;
using Todomorrow.Application.Epics;
using Todomorrow.Application.Features;
using Todomorrow.Application.Organizations;
using Todomorrow.Application.Partners;
using Todomorrow.Application.Projects;
using Todomorrow.Application.SoftSkills;
using Todomorrow.Application.Subcategories;
using Todomorrow.Application.Users;
using Todomorrow.Application.UserSkills;
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

namespace Todomorrow.Api.Dependencies
{
    public static class DomainServiceDependency
    {
        public static void AddServices(this IServiceCollection services)
        {
            _ = services.AddScoped<IUserService, UserService>();
            _ = services.AddScoped<IEpicService, EpicService>();
            _ = services.AddScoped<IWorkItemService, WorkItemService>();
            _ = services.AddScoped<IProjectService, ProjectService>();
            _ = services.AddScoped<IActionItemService, ActionItemService>();
            _ = services.AddScoped<IOrganizationService, OrganizationService>();
            _ = services.AddScoped<IPartnerService, PartnerService>();
            _ = services.AddScoped<ISoftSkillService, SoftSkillService>();
            _ = services.AddScoped<ICategoryService, CategoryService>();
            _ = services.AddScoped<ISubcategoryService, SubcategoryService>();
            _ = services.AddScoped<IUserSkillService, UserSkillService>();
        }
    }
}