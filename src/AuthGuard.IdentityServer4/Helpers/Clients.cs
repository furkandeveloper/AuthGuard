using IdentityServer4;
using IdentityServer4.Models;

namespace AuthGuard.IdentityServer4.Helpers
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
        {
            new Client
            {
                ClientId = "employeeApi",
                ClientName = "Employee Service",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = new List<Secret> {new Secret("ProCodeGuide".Sha256())},
                AllowedScopes = new List<string> {"employeeApi.read", "employeeApi.create", "employeeApi.update", "employeeApi.delete" }
            }
        };
        }
    }
}
