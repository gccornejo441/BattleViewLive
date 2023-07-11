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
using Microsoft.IdentityModel.Tokens;
using System.Text;

DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();

// Adding JWT Services
// An authentication scheme is named when the authentication service is configured during authentication.
// two authentication handlers have been added: one for cookies and one for bearer.

builder.Services.AddAuthentication()
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Unauthorized/";
            options.AccessDeniedPath = "/Account/Forbidden/";
        })
        .AddJwtBearer(options =>
        {
            // Setting up with custom options
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,  // API will check for valid user based on view authority
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });


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

app.UseAuthorization();
app.UseAuthentication();
app.Run();
