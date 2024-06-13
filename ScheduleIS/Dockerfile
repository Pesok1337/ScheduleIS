# Базовый образ для ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 7076

# Образ для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ScheduleIS/ScheduleIS.API.csproj", "ScheduleIS/"]
RUN dotnet restore "./ScheduleIS/ScheduleIS.API.csproj"
COPY . .
WORKDIR "/src/ScheduleIS"
RUN dotnet build "./ScheduleIS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Образ для публикации проекта
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ScheduleIS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Финальный образ для запуска приложения
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScheduleIS.API.dll"]
