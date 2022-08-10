using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace MeetupManager.Identity
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("MeetupAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("MeetupAPI")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "meetup-web-api",
                    ClientSecrets = { new Secret("client_secret_meetup".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    
                    AllowedCorsOrigins = { "https://localhost:7186", "http://localhost:5186" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MeetupAPI"
                    }
                }
            };
    }
}
