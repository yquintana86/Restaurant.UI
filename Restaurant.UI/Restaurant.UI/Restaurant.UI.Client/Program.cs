using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Restaurant.UI.Client;
using Restaurant.UI.Client.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();




