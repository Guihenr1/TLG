# First stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY src/TLG.Application/*.csproj ./src/TLG.Application/
COPY src/TLG.Core/*.csproj ./src/TLG.Core/
COPY src/TLG.Infrastructure/*.csproj ./src/TLG.Infrastructure/
COPY src/TLG.Api/*.csproj ./src/TLG.Api/
RUN dotnet restore

# Copy everything else and build website
COPY src/TLG.Application/. ./src/TLG.Application/
COPY src/TLG.Core/. ./src/TLG.Core/
COPY src/TLG.Infrastructure/. ./src/TLG.Infrastructure/
COPY src/TLG.Api/. ./src/TLG.Api/
WORKDIR /app/src/TLG.Api
RUN dotnet publish -c release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TLG.Api.dll"]