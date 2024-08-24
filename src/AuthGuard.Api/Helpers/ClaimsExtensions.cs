using System.Security.Claims;

namespace AuthGuard.Api.Helpers
{
    public static class ClaimsExtensions
    {
        public static string[] GetScope(this IEnumerable<Claim> claims)
        {
            var scopes = claims?.Where((Claim x) => x.Type == "scope").Select(s => s.Value).ToArray();
            return scopes;
        }
    }
}
