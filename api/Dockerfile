FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore

RUN dotnet publish -c Release -o out

# Build runtime imagedo
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Vill ha curl för healtcheck
RUN apt-get update && apt-get install -y curl

ENTRYPOINT ["dotnet", "DemoApi.dll"]