using System;
using System.Net.Http;
using IdentityModel;
using IdentityModel.Client;
using Xunit;

namespace Sample.Api.Test
{
    public class IndetityServerTest
    {
        [Fact]
        public async void get_token()
        {
            var client = new HttpClient();

            var response = await client.RequestTokenAsync(new TokenRequest
            {
                Address = "http://localhost:5000/connect/token",
                GrantType = OidcConstants.GrantTypes.ClientCredentials,
                ClientId = "client1",
                ClientSecret = "client1secret",
                Parameters =
                {
                    { "scope", "IdentityServerApi" }
                }
            });
            Assert.NotNull(response.AccessToken);
        }
    }
}