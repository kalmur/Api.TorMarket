using Api.TorMarket.Application;
using Api.TorMarket.Infrastructure;
using Api.TorMarket.Persistence;
using Api.TorMarket.WebApi.Services;
using Microsoft.OpenApi.Models;
using HttpResponse = Api.TorMarket.WebApi.Services.HttpResponse;

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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsBuilder =>
    {
        corsBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddControllers();

builder.Services.AddScoped<IHttpResponse, HttpResponse>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
