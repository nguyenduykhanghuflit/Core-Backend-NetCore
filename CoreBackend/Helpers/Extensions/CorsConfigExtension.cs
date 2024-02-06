using Microsoft.OpenApi.Models;

namespace CoreBackend.Helpers.Extensions
{
    public static class CorsConfigExtension
    {
        public static IServiceCollection CorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("https://goldenpos.vn", "http://crm.senvangsolutions.com")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            return services;
        }
    }
}
