using CoreBackend.Helpers.ActionFilters;
using CoreBackend.Helpers.Extensions;
using CoreBackend.Helpers.Middlewares;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);



#region Service


builder.Services.CorsConfig();

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddEndpointsApiExplorer();


builder.Services.SwaggerConfig();

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddControllers(o => o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddSwaggerGen();

#endregion


#region App
var app = builder.Build();

app.UseCors("AllowSpecificOrigins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

#endregion