#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
COPY ["apiGateway/ApiGateway.Api/apiGateway.csproj", "/apigateway"]
COPY . .
WORKDIR /apiGateway/ApiGateway.Api/
RUN dotnet build "apiGateway.csproj" -c Release

FROM build AS publish
RUN dotnet publish "apiGateway.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "apiGateway.dll"]