using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                 new ApiResource
                 {
                    Name = "Banking.Api"
                 },
                 new ApiResource
                 {
                    Name = "Transfer.Api"
                 }
            };
        }

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                 new ApiScope("Banking.Api","Banking Api") ,
                 new ApiScope("Transfer.Api","Transfer Api")
            };

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                 new Client
                 {
                    ClientId = "StsClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("secret".Sha256())}, // change me!
                    AllowedScopes = new List<string> { "Banking.Api", "Transfer.Api" }
                 }
          };
        }

        public static List<TestUser> TestUsers => 
            new List<TestUser> { };
    }
}