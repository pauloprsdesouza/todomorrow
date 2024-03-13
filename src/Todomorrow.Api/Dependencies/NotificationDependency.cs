using Microsoft.Extensions.DependencyInjection;
using Todomorrow.Domain.Notifications;

namespace Todomorrow.Api.Dependencies
{
    public static class NotificationDependency
    {
        public static void AddNotifications(this IServiceCollection services)
        {
            _ = services.AddScoped<INotificationContext, NotificationContext>();
        }
    }
}
