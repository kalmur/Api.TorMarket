using Api.TorMarket.Application;
using Api.TorMarket.Infrastructure;
using Api.TorMarket.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(x =>
    {
        x.SwaggerDoc("v1", 
            new OpenApiInfo
            {
                Title = "Api.TorMarket", 
                Version = "v1"
            }
        );
    });

builder.Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(corsBuilder =>
        {
            corsBuilder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
