#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HA.LightningService/HA.LightningService.csproj", "HA.LightningService/"]
RUN dotnet restore "HA.LightningService/HA.LightningService.csproj"
COPY . .
WORKDIR "/src/HA.LightningService"
RUN dotnet build "HA.LightningService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HA.LightningService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HA.LightningService.dll"]