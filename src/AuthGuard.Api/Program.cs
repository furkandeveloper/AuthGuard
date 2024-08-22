using AuthGuard.Api.Helpers;
using AuthGuard.Application;
using AuthGuard.EntityFrameworkCore;
using AuthGuard.Infrastructure.Exceptions;
using AuthGuard.Infrastructure.Repository;
using EasyCache.Memory.Extensions;
using EasyWeb.AspNetCore.ApiStandarts;
using EasyWeb.AspNetCore.Filters;
using FluentValidation.AspNetCore;
using MarkdownDocumenting.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
        JsonConvert.DefaultSettings = () => options.SerializerSettings;
    })
    .AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()))
    .AddEasyWebCore();

builder.Services.ConfigureWebApiStandarts();

builder.Services.AddDbContext<AuthGuardDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddEasyMemoryCache();

#region Object Mapping
builder.Services.AddAutoMapper((sp, cfg) =>
{
    cfg.ConstructServicesUsing(sp.GetService);
}, AppDomain.CurrentDomain.GetAssemblies());

#endregion

builder.Services.AddApplicationServices();

builder.Services.ApplyGenericRepositoryPattern<AuthGuardDbContext>();

builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "employeeApi";
        options.Authority = builder.Configuration.GetValue<string>("IdentityServerOptions:Authority");
    });

builder.Services.AddSwaggerGen(options =>
{
    var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        var title = "Auth Guard Service";
        options.SwaggerDoc(description.GroupName, new OpenApiInfo()
        {
            Title = description.IsDeprecated ? title + "- [Deprecated]" : title,
            Version = description.ApiVersion.ToString(),
            Description = "RoofStack Auth Guard Service",
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html"),
            }
        });
    }

    options.OperationFilter<DefaultValuesOperationFilter>();
    options.OperationFilter<AuthorizationOperationFilter>();
    options.OperationFilter<ContentTypeOperationFilter>();

    options.DocumentFilter<CamelCaseDocumentFilter>();
    options.DocumentFilter<BearerSecurityDocumentFilter>();

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Bearer",
        In = ParameterLocation.Header,
        Description = "Jwt Berarer token from Auth Guard"
    });
});

builder.Services.AddDocumentation();

var app = builder.Build();

app.UseEasyExceptionHandler();

app.UseDocumentation(config =>
{
    config.HighlightJsStyle =
        "https://cdnjs.cloudflare.com/ajax/libs/highlight.js/9.13.1/styles/github.min.css";
    config.GetMdlStyle = "https://code.getmdl.io/1.1.3/material.teal-orange.min.css";
    config.RootPathHandling = HandlingType.Redirect;
    config
        .AddCustomLink(new MarkdownDocumenting.Elements.CustomLink("Swagger", "/api-docs"))
        .AddCustomLink(new MarkdownDocumenting.Elements.CustomLink("ReDoc", "/api-docs-redoc"));
});

app.UseSwagger();

app.UseReDoc(options =>
{
    options.SpecUrl = "/swagger/1.0/swagger.json";
    options.RoutePrefix = "api-docs-redoc";
});

var versioningProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

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
    foreach (var description in versioningProvider.ApiVersionDescriptions)
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();