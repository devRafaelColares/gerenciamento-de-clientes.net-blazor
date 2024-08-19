using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Form_Cad_Clientes_v2._0.Web;
using MudBlazor.Services;
using Form_Cad_Clientes_v2._0.Web.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Adiciona os componentes principais do Blazor
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura os serviços do MudBlazor
builder.Services.AddMudServices();

// Configura o HttpClient para se comunicar com o backend usando a URL base definida em Configuration
builder.Services.AddHttpClient(Configuration.HttpClient, options => {
    options.BaseAddress = new Uri(Configuration.BackendUrl);
});
// .AddHttpMessageHandler<CookieHandler>();
// Executa a aplicação

builder.Services.AddScoped<ClientesService>();

await builder.Build().RunAsync();
