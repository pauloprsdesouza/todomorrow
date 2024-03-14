using Microsoft.Extensions.DependencyInjection;
using Todomorrow.Infrastructure.Mappers;

namespace Todomorrow.Api.Dependencies
{
    public static class MapperProfileDependency
    {
        public static void AddMapperProfiles(this IServiceCollection services)
        {
            _ = services.AddAutoMapper(
                                   typeof(ActionItemProfile),
                                   typeof(ProjectProfile),
                                   typeof(WorkItemProfile),
                                   typeof(EpicProfile),
                                   typeof(UserProfile),
                                   typeof(OrganizationProfile),
                                   typeof(CategoryProfile),
                                   typeof(SubcategoryProfile),
                                   typeof(SoftSkillProfile),
                                   typeof(UserSkillProfile));
        }
    }
}
