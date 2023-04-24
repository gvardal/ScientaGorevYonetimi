using Microsoft.AspNetCore.Components.Authorization;

namespace ScientaScheduler.Blazor.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
