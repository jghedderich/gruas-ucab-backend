using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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

// Esta relacionado con Keycloak, no se lo que estoy haciendo
builder.Services
    .AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:8080/realms/gruas";
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidAudiences = ["account"],
            ValidIssuers = ["http://localhost:8080/realms/gruas"]
        };
    });

// talvez sea eliminado, o cambiado, no se que estoy haciendo
builder.Services
    .AddAuthorizationBuilder()
    .AddPolicy("first-api-access", policy =>
        policy.RequireAuthenticatedUser()
        .RequireClaim("first-api-access", true.ToString()))
    .AddPolicy("second-api-access", policy =>
        policy.RequireAuthenticatedUser()
        .RequireClaim("second-api-access", true.ToString()));


var AllowedOrigins = "clientApps";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowedOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:3000");
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
        builder.AllowCredentials();
    });
});

var app = builder.Build();

// talvez sea eliminado o cambiado, repito, no se lo que estoy haciendo
app.MapGet("login", (bool firstApi = false, bool secondApi = false) => 
    Results.SignIn(
    new ClaimsPrincipal(
        new ClaimsIdentity(
            [
                new Claim("sub", Guid.NewGuid().ToString()),
                new Claim("first-api-access", firstApi.ToString()),
                new Claim("second-api-access", secondApi.ToString()),
            ],
            BearerTokenDefaults.AuthenticationScheme
            )),
    authenticationScheme: BearerTokenDefaults.AuthenticationScheme
    ));

app.UseRateLimiter();

app.UseCors(AllowedOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapReverseProxy();

app.Run();
