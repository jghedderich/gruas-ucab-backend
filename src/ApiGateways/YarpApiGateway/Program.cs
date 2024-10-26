var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Add YARP al contenedor de servicios
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Configure the HTTP request pipeline
// Usar YARP como middleware para el reverse proxy
app.MapReverseProxy();

app.Run();
