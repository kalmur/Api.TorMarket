# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Api.TorMarket.WebApi/Api.TorMarket.WebApi.csproj", "Api.TorMarket.WebApi/"]
COPY ["Api.TorMarket.Application/Api.TorMarket.Application.csproj", "Api.TorMarket.Application/"]
COPY ["Api.TorMarket.Domain/Api.TorMarket.Domain.csproj", "Api.TorMarket.Domain/"]
COPY ["Api.TorMarket.Infrastructure/Api.TorMarket.Infrastructure.csproj", "Api.TorMarket.Infrastructure/"]
COPY ["Api.TorMarket.Persistence/Api.TorMarket.Persistence.csproj", "Api.TorMarket.Persistence/"]
RUN dotnet restore "./Api.TorMarket.WebApi/Api.TorMarket.WebApi.csproj"
COPY . .
WORKDIR "/src/Api.TorMarket.WebApi"
RUN dotnet build "./Api.TorMarket.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.TorMarket.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.TorMarket.WebApi.dll"]