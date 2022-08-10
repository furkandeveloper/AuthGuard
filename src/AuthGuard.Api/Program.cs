using AuthGuard.Api.Helpers;
using AuthGuard.Application;
using AuthGuard.EntityFrameworkCore;
using AuthGuard.Infrastructure.Repository;
using EasyWeb.AspNetCore.ApiStandarts;
using EasyWeb.AspNetCore.Filters;
using EasyWeb.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

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

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("1",
        new OpenApiInfo
        {
            Title = "Auth Guard Service",
            Version = "1",
            Description = "v1 - Auth Guard Service"
        });

    var docFile = $"{Assembly.GetEntryAssembly()?.GetName().Name}.xml";
    var filePath = Path.Combine(AppContext.BaseDirectory, docFile);

    if (System.IO.File.Exists((filePath)))
    {
        c.IncludeXmlComments(filePath);
    }

    c.DescribeAllParametersInCamelCase();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Bearer",
        In = ParameterLocation.Header,
        Description = "Jwt Berarer token from Auth Guard"
    });
    c.DocumentFilter<LowercaseDocumentFilter>();
    c.OperationFilter<AuthorizationOperationFilter>();
    c.OperationFilter<DefaultValuesOperationFilter>();
});

var app = builder.Build();

app.UseSwagger();

app.UseReDoc(options =>
{
    options.SpecUrl = "/swagger/1/swagger.json";
    options.RoutePrefix = "api-docs-redoc";
});

app.UseSwaggerUI(options =>
{
    options.EnableDeepLinking();
    options.ShowExtensions();
    options.DisplayRequestDuration();
    options.DisplayOperationId();
    options.DocExpansion(DocExpansion.None);
    options.EnableFilter();
    options.EnableValidator();
    options.ShowCommonExtensions();
    options.ShowExtensions();
    options.RoutePrefix = "api-docs";
    options.SwaggerEndpoint($"{builder.Configuration.GetValue<string>("BasePath")}/swagger/1/swagger.json", "V1");
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();