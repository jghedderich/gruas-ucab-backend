using Admin.Infrastructure;
using Admin.Application;
using Admin.Infrastructure.Data.Extensions;
using Admin.API;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

var firebaseApp = FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(Path.Combine(Directory.GetCurrentDirectory(), "firebase-credentials.json"))
});

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();





app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabase();
}

app.Run();
