using System.Text.Json;
using System.Text.Json.Serialization;

namespace Todomorrow.Infrastructure.Serialization
{
    public static class ApiJsonSerializerOptions
    {
        public static JsonSerializerOptions Default(this JsonSerializerOptions options)
        {
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.Converters.Add(new JsonStringEnumConverter());
            options.ReferenceHandler = ReferenceHandler.IgnoreCycles;

            return options;
        }
    }
}
