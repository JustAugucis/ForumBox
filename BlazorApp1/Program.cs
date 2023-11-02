using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp1.Data;
using BlazorWasm.Auth;
using BlazorWasm.Services;
using BlazorWasm.Services.Http;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IPostService, PostHttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7078")});

AuthorizationPolicies.AddPolicies(builder.Services);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();