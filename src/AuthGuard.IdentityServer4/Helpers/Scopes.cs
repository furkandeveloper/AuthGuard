using IdentityServer4.Models;

namespace AuthGuard.IdentityServer4.Helpers
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("employeeApi.read", "Read Access to Employee API"),
                new ApiScope("employeeApi.create", "Create Access to Employee API"),
                new ApiScope("employeeApi.update", "Update Access to Employee API"),
                new ApiScope("employeeApi.delete", "Delete Access to Employee API"),
            };
        }
    }
}
