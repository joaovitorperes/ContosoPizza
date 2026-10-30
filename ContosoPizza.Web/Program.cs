using ContosoPizza.Web.Components;
using ContosoPizza.Web.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("PizzaApi", client =>
{
    client.BaseAddress =
        new Uri("https://localhost:7084/");
});

builder.Services.AddScoped<PizzaApiService>();
builder.Services.AddScoped<AuthApiService>();
builder.Services.AddScoped<AuthState>();

// FALTA ESTA LINHA
builder.Services.AddScoped<ProtectedSessionStorage>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();