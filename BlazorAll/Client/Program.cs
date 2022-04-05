global using BlazorAll.Shared.Models;
global using Microsoft.AspNetCore.Components.Authorization;
global using System.Net.Http.Json;
global using Blazored.LocalStorage;
global using BlazorAll.Client.Services;

using BlazorAll.Client;
using BlazorAll.Client.Services.LoginService;
using BlazorAll.Client.Services.SuperHeroService;
using BlazorAll.Client.Services.WeatherService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<ILoginService, LoginService>();

builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
