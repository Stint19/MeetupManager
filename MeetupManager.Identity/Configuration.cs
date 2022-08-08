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
                new ApiScope("MeetupWebAPI", "Web API")
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
                new ApiResource("MeetupWebAPI", "Web API", new [] { JwtClaimTypes.Name })
                {
                    Scopes = {"MeetupWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "meetup-web-api",
                    ClientName = "Meetup Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:7186/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "https://localhost:7186/"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7186/signout-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "MeetupWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}
