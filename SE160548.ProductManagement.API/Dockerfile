# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY SE160548.ProductManagement.API/*.csproj ./SE160548.ProductManagement.API/
RUN dotnet restore

# copy everything else and build app
COPY SE160548.ProductManagement.API/. ./SE160548.ProductManagement.API/
WORKDIR /src/SE160548.ProductManagement.API
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "SE160548.ProductManagement.API.dll"]
