using EasyWeb.AspNetCore.ApiStandarts;
using EasyWeb.AspNetCore.Filters;

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

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Run();