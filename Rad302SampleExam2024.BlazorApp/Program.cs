using DataServices;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Rad302SampleExam2024.BlazorApp;
using System.Net.NetworkInformation;
using Tracker.WebAPIClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>(
                sp => {
                    sp.BaseAddress = new Uri("https://localhost:7109");
                });

builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddSingleton<AppState>();
//builder.Services.AddScoped<NavigationManager>();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var _localservice = scope.ServiceProvider.GetRequiredService<ILocalStorageService>();
    var _appState = scope.ServiceProvider.GetRequiredService<AppState>();
    // Clear the Token if set
    await _localservice.RemoveItem("token");
    // set loged out
    _appState.LoggedIn = false;
}
await app.RunAsync();
