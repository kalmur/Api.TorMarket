using Api.TorMarket.Application;
using Api.TorMarket.Infrastructure;
using Api.TorMarket.Persistence;
using Api.TorMarket.WebApi;
using Asp.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies(builder.Configuration)
    .AddPersistenceDependencies(builder.Configuration)
    .AddWebApiDependencies()
    .AddAuthorization()
    .AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(options =>
    {
        options.SwaggerDoc(
            "v1",
            new OpenApiInfo
            {
                Title = "Api.TorMarket",
                Version = "v1"
            }
        );
    });

builder.Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
        options.ReportApiVersions = true;
    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
