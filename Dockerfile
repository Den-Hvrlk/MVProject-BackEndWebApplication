# Этап сборки
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Этап для публикации
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["BackEndWebApplication/BackEndWebApplication.csproj", "BackEndWebApplication/"]
RUN dotnet restore "BackEndWebApplication/BackEndWebApplication.csproj"
COPY . . 
WORKDIR "/src/BackEndWebApplication"
RUN dotnet build "BackEndWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackEndWebApplication.csproj" -c Release -o /app/publish

# Финальный этап — создание изображения
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEndWebApplication.dll"]
