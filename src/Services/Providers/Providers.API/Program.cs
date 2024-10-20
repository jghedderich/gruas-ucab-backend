using BuildingBlocks.API;
using BuildingBlocks.Application;
using Providers.Infrastructure;
using Providers.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

// Configure HTTP run pipeline
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabase();
}

app.Run();
