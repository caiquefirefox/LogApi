#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Log.API/Log.API.csproj", "Log.API/"]
COPY ["Log.Domain/Log.Domain.csproj", "Log.Domain/"]
COPY ["Log.Toolkit/Log.Toolkit.csproj", "Log.Toolkit/"]
RUN dotnet restore "Log.API/Log.API.csproj"
COPY . .
WORKDIR "/src/Log.API"
RUN dotnet build "Log.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Log.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Log.API.dll"]
#docker build -t caiquedev94/logapiapp:1.0 -f Log.Infra/Docker/App/Dockerfile .
#docker run --link influxdb --net=log-compose-network -p 80:3772 -d --name log.api 023f045cc6b8