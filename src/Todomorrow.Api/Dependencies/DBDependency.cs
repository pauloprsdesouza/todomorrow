using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todomorrow.Infrastructure.Database.DataModel;

namespace Todomorrow.Api.Dependencies
{
    public static class DBDependency
    {
        public static void AddDbContextDependency(this IServiceCollection services, IConfiguration configuration)
        {
            _ = services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Aurora"), cfg => cfg.MigrationsHistoryTable("__EFMigrationsHistory", "todomorrow")));
        }
    }
}