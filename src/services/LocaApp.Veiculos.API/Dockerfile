#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/services/LocaApp.Veiculos.API/LocaApp.Veiculos.API.csproj", "src/services/LocaApp.Veiculos.API/"]
RUN dotnet restore "src/services/LocaApp.Veiculos.API/LocaApp.Veiculos.API.csproj"
COPY . .
WORKDIR "/src/src/services/LocaApp.Veiculos.API"
RUN dotnet build "LocaApp.Veiculos.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocaApp.Veiculos.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocaApp.Veiculos.API.dll"]