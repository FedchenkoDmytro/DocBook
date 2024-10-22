#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DocBook.WebAPI/DocBook.WebAPI.csproj", "src/DocBook.WebAPI/"]
COPY ["src/DocBook.Core/DocBook.Core.csproj", "src/DocBook.Core/"]
COPY ["src/DocBook.Data/DocBook.Data.csproj", "src/DocBook.Data/"]
RUN dotnet restore "./src/DocBook.WebAPI/DocBook.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/DocBook.WebAPI"
RUN dotnet build "./DocBook.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DocBook.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DocBook.WebAPI.dll"]

## Run migrations
FROM build as migrations
WORKDIR /src
RUN dotnet tool install --version 8.0.10 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT dotnet-ef database update --project src/DocBook.Data/ --startup-project src/DocBook.WebAPI/