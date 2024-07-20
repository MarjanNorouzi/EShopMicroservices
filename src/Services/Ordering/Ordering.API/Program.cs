var builder = WebApplication.CreateBuilder(args);

// Add Services to the containerxx

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

// Configure Http request Pipeline
app.UseApiServices();

if(app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();
