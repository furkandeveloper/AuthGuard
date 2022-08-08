using IdentityServer4.Models;

namespace AuthGuard.IdentityServer4.Helpers
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> {"role"}
            }
        };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
            new ApiResource
            {
                Name = "employeeApi",
                DisplayName = "Employee Api",
                Description = "Allow the application to access Employee Api on your behalf",
                Scopes = new List<string> {"employeeApi.read", "employeeApi.create", "employeeApi.update", "employeeApi.delete" },
                ApiSecrets = new List<Secret> {new Secret("ProCodeGuide".Sha256())},
                UserClaims = new List<string> {"role"}
            }
        };
        }
    }
}
