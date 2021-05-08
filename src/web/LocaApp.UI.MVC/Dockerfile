#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/web/LocaApp.UI.MVC/LocaApp.UI.MVC.csproj", "src/web/LocaApp.UI.MVC/"]
RUN dotnet restore "src/web/LocaApp.UI.MVC/LocaApp.UI.MVC.csproj"
COPY . .
WORKDIR "/src/src/web/LocaApp.UI.MVC"
RUN dotnet build "LocaApp.UI.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocaApp.UI.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocaApp.UI.MVC.dll"]