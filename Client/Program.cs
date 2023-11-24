using BlazorApp1.Client;
using BlazorApp1.Client.Auth;
using BlazorApp1.Client.Helpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Runtime.CompilerServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

ConfigureServices(builder.Services);

await builder.Build().RunAsync();

 static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<Irepository, RepositoryInMemory>();
    services.AddAuthorizationCore();
    services.AddScoped<JWTAuthenticationStateProvider>();
    services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>
        (
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
        );

    services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
        provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());

}
