using Orders.Infrastructure;
using Orders.Application;
using Orders.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure HTTP run pipeline
app.UseApiServices();

// if (app.Environment.IsDevelopment())
// {
//    await app.InitializeDatabase();
// }

app.Run();
