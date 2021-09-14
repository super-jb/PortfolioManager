#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PortfolioManager.API.PortofolioApi/PortfolioManager.API.PortofolioApi.csproj", "PortfolioManager.API.PortofolioApi/"]
RUN dotnet restore "PortfolioManager.API.PortofolioApi/PortfolioManager.API.PortofolioApi.csproj"
COPY . .
WORKDIR "/src/PortfolioManager.API.PortofolioApi"
RUN dotnet build "PortfolioManager.API.PortofolioApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioManager.API.PortofolioApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PortfolioManager.API.PortofolioApi.dll"]