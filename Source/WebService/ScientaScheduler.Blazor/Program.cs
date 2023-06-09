using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ScientaScheduler.Blazor.Data;
using ScientaScheduler.Blazor.Services;
using ScientaScheduler.Blazor.Services.Infrastructure;
using ScientaScheduler.Blazor.Services.Interface;
using Syncfusion.Blazor;

namespace ScientaScheduler.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthenticationCore();
            builder.Services.AddSyncfusionBlazor();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider,AuthStateProvider>();

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<IBusinessService,BusinessService>();

            var app = builder.Build();

            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrXVNbdV5dVGpAd0N3RGlcdlR1fUUmHVdTRHRcQl5hQX5Rd0ZiWHlYcnI=;Mgo+DSMBPh8sVXJ1S0d+X1RPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSX1RfkVhWHxfcXJSQGY=;ORg4AjUWIQA/Gnt2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdE1jW35dcXVTT2Fa;MTQ5MjU2OEAzMjMxMmUzMTJlMzMzNWM0THlOZWYxVUh3S2R5VlpwOHRuU3JIaWhMRHpFYnpxQVE4KzJOSUtZTmc9;MTQ5MjU2OUAzMjMxMmUzMTJlMzMzNUMrRjY5eEZVUzlkb2hjc3RadnVreGd5SUNCVnI5ODUwZWZHaTBkYWZrK3M9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdUdrWX1fc3VUQWleVw==;MTQ5MjU3MUAzMjMxMmUzMTJlMzMzNUtEdWFiSzY1RUFxeVRheTFYb0RjZWdTNUQ4VDVtNWdoRXFTZ0I4eXFzNVE9;MTQ5MjU3MkAzMjMxMmUzMTJlMzMzNUNBbE1EWTNrRC8yRzdEQTdkc2dheE9vVTB5L0V2TU1SSjRCSnF6K1ZVMzA9;Mgo+DSMBMAY9C3t2VFhhQlJBfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5QdE1jW35dcXVcQ2Va;MTQ5MjU3NEAzMjMxMmUzMTJlMzMzNWpGS29uWVFmSTRNeWpYNjJlQmc0djg2R0pkZzhydjhpMncxaFdvYmp6OVk9;MTQ5MjU3NUAzMjMxMmUzMTJlMzMzNUVDeWhoR2JobTc5czlReVgwaW54WlBMMzFHN3dpekF5eVlBQmtXV25Cd2s9;MTQ5MjU3NkAzMjMxMmUzMTJlMzMzNUtEdWFiSzY1RUFxeVRheTFYb0RjZWdTNUQ4VDVtNWdoRXFTZ0I4eXFzNVE9");

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}