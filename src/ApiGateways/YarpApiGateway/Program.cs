using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var AllowedOrigins = "clientApps";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowedOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:3000");
        builder.WithOrigins("http://localhost:3001");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.AllowCredentials();
    });
});

builder.Services
    .AddAuthentication(BearerTokenDefaults.AuthenticationScheme)
    .AddBearerToken();

var app = builder.Build();

app.UseRateLimiter();

app.UseCors(AllowedOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();

app.Run();
