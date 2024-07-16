var builder = WebApplication.CreateBuilder(args);

// Add Services to the containerxx

//------------
// Infrastructure - EF
// Application - MediatR
// Api - carter, health  check, ...

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();
//-------------


var app = builder.Build();

// Configure Http request Pipeline

app.Run();
