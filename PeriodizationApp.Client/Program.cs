using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PeriodizationApp.Client;
using PeriodizationApp.Client.Services;
using ApexCharts;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Detección dinámica de red:
// - En PC (https://localhost:7114) -> conecta a https://localhost:7098/
// - En Celular por Wi-Fi (http://<IP_LOCAL>:5226) -> conecta a http://<IP_LOCAL>:5199/
// - En Nube / Túnel -> puede usar configuración ApiBaseUrl o el mismo origen
var clientUri = new Uri(builder.HostEnvironment.BaseAddress);
var configuredApiUrl = builder.Configuration["ApiBaseUrl"];
Uri apiBaseUri;

if (!string.IsNullOrWhiteSpace(configuredApiUrl))
{
    apiBaseUri = new Uri(configuredApiUrl);
}
else if (clientUri.Scheme == "https" && clientUri.IsLoopback)
{
    apiBaseUri = new Uri($"https://{clientUri.Host}:7098/");
}
else if (clientUri.Port == 5226 || clientUri.Port == 7114)
{
    var targetPort = clientUri.Scheme == "https" ? 7098 : 5199;
    apiBaseUri = new Uri($"{clientUri.Scheme}://{clientUri.Host}:{targetPort}/");
}
else
{
    // Cuando se sirve unificado desde el mismo dominio/túnel en producción
    apiBaseUri = new Uri(builder.HostEnvironment.BaseAddress);
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = apiBaseUri });
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddApexCharts();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
