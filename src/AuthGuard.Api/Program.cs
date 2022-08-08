using EasyWeb.AspNetCore.ApiStandarts;
using EasyWeb.AspNetCore.Filters;
using EasyWeb.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddEasyWebCore();

builder.Services.ConfigureWebApiStandarts();

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "employeeApi";
        options.Authority = builder.Configuration.GetValue<string>("IdentityServerOptions:Authority");
    });

builder.Services.ConfigureSwagger(options =>
{
    options.Title = "Employee Service";
    options.Description = "Auth Guard Employee Service";
});

var app = builder.Build();

app.ApplySwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Run();