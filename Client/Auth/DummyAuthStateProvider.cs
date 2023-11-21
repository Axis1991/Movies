using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Security.Claims;

namespace BlazorApp1.Client.Auth
{
    public class DummyAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            var annonymous = new ClaimsIdentity(new List<Claim> {
            new Claim("key1", "value1"),
            new Claim(ClaimTypes.Name, "Gee"),
            new Claim(ClaimTypes.Role, "Admin")
            });
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(annonymous)));

            // also works with "test" parameter in await Task.
        }
    }
}
