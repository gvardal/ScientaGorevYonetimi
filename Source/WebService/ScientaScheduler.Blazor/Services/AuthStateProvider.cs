using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ScientaScheduler.Blazor.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationState anonymous;
        private HttpClient client;

        public AuthStateProvider(ILocalStorageService localStorageService, HttpClient client)
        {
            this.localStorageService = localStorageService;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            this.client = client;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token))
                return anonymous;

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token.Replace("\"", null));
            IEnumerable<Claim> jwtClaims = securityToken.Claims;
            var claims = new ClaimsPrincipal();
            foreach (var item in jwtClaims)
            {
                claims.AddIdentity(new ClaimsIdentity(new[] { new Claim(item.Type, item.Value) }, "jwtAuthType"));
            }
            return new AuthenticationState(claims);
        }

        public async Task NotifyUserLogin()
        {
            string token = await localStorageService.GetItemAsync<string>("token");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token.Replace("\"", null));
            IEnumerable<Claim> jwtClaims = securityToken.Claims;
            var claims = new ClaimsPrincipal();
            foreach (var item in jwtClaims)
            {
                claims.AddIdentity(new ClaimsIdentity(new[] { new Claim(item.Type, item.Value) }, "jwtAuthType"));
            }
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
