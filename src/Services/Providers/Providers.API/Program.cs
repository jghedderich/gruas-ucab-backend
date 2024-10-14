using BuildingBlocks.API;
using BuildingBlocks.Application;
using BuildingBlocks.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

// Configure HTTP run pipeline

app.Run();
