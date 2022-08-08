var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddIdentityServer()
    .AddInMemoryClients(AuthGuard.IdentityServer4.Helpers.Clients.Get())
    .AddInMemoryIdentityResources(AuthGuard.IdentityServer4.Helpers.Resources.GetIdentityResources())
    .AddInMemoryApiResources(AuthGuard.IdentityServer4.Helpers.Resources.GetApiResources())
    .AddInMemoryApiScopes(AuthGuard.IdentityServer4.Helpers.Scopes.GetApiScopes())
    .AddTestUsers(AuthGuard.IdentityServer4.Helpers.Users.Get())
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseIdentityServer();

app.MapControllers();

app.MapDefaultControllerRoute();

app.Run();