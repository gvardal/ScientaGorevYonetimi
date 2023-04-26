using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ScientaScheduler.Blazor.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationState anonymous;

        public AuthStateProvider(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(anonymous);
        }


        private async Task<string> GetToken()
        {
            return await localStorageService.GetItemAsync<string>("token");
        }


        public async Task NotifyUserLogin()
        {
            string token = await localStorageService.GetItemAsync<string>("token");

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token.Replace("\"",null));
            IEnumerable<Claim> jwtClaims = securityToken.Claims;

            var claims = new ClaimsPrincipal();
           
            foreach (var item in jwtClaims)
            {
                claims.AddIdentity(new ClaimsIdentity(new[] { new Claim(item.Type,item.Value) }, "jwtAuthType"));
            }
            //var claims = new ClaimsPrincipal
            //    (
            //        new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, jwtClaims.First().Value), }, "jwtAuthType")
            //    );

            var authState = Task.FromResult(new AuthenticationState(claims));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);

        }
    }
}
