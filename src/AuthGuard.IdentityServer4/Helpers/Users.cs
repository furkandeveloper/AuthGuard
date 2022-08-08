using IdentityModel;
using IdentityServer4.Test;
using System.Security.Claims;

namespace AuthGuard.IdentityServer4.Helpers
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "56892347",
                    Username = "furkan",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email, "furkan.dvlp@gmail.com"),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }
                }
            };
        }
    }
}
