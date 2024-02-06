using CoreBackend.Helpers.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


#region Service
builder.Services.AddEndpointsApiExplorer();

builder.Services.CorsConfig();

builder.Services.SwaggerConfig();
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

#endregion


#region App


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
//app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

#endregion