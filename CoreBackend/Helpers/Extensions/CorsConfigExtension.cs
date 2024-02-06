using Microsoft.OpenApi.Models;

namespace CoreBackend.Helpers.Extensions
{
    public static class CorsConfigExtension
    {
        public static IServiceCollection CorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", x => x.AllowAnyHeader().
                                                    AllowAnyOrigin().
                                                    AllowAnyMethod());
            });
            return services;
        }
    }
}
