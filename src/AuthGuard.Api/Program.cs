using AuthGuard.Application;
using AuthGuard.EntityFrameworkCore;
using AuthGuard.Infrastructure.Repository;
using EasyWeb.AspNetCore.ApiStandarts;
using EasyWeb.AspNetCore.Filters;
using EasyWeb.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddEasyWebCore();

builder.Services.ConfigureWebApiStandarts();

builder.Services.AddDbContext<AuthGuardDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

#region Object Mapping
builder.Services.AddAutoMapper((sp, cfg) =>
{
    cfg.ConstructServicesUsing(sp.GetService);
}, AppDomain.CurrentDomain.GetAssemblies());

#endregion

builder.Services.AddApplicationServices();

builder.Services.ApplyRepository<AuthGuardDbContext>();

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

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();