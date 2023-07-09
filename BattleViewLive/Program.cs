using BattleViewLive.Api.Entities;
using BattleViewLive.Authentication;
using BattleViewLive.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Dapper;
using BattleViewLive.Services.Interfaces;
using BattleViewLive.Services;
using Npgsql;

DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<BattleviewContext>(options =>
{
    var conStrBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("connectionString"));
    options.UseNpgsql(conStrBuilder.ConnectionString);
});
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IDbService, DbService>();
builder.Services.AddScoped<UserAccountService>();
builder.Services.AddSingleton<WeatherForecastService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
