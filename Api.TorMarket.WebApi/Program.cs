using Api.TorMarket.Application;
using Api.TorMarket.Infrastructure;
using Api.TorMarket.Persistence;
using Api.TorMarket.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationDependencies()
    .AddInfrastructureDependencies(builder.Configuration)
    .AddPersistenceDependencies(builder.Configuration)
    .AddWebApiDependencies()
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();