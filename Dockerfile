FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore "BackEndWebApplication/BackEndWebApplication.csproj"
RUN dotnet publish "BackEndWebApplication/BackEndWebApplication.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BackEndWebApplication.dll"]
