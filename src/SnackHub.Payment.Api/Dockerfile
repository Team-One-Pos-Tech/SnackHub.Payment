#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SnackHub.Payment.Api/SnackHub.Payment.Api.csproj", "src/SnackHub.Payment.Api/"]
COPY ["src/SnackHub.Payment.Ioc/SnackHub.Payment.Ioc.csproj", "src/SnackHub.Payment.Ioc/"]
COPY ["src/SnackHub.Payment.Application/SnackHub.Payment.Application.csproj", "src/SnackHub.Payment.Application/"]
COPY ["src/SnackHub.Payment.Domain/SnackHub.Payment.Domain.csproj", "src/SnackHub.Payment.Domain/"]
RUN dotnet restore "./src/SnackHub.Payment.Api/./SnackHub.Payment.Api.csproj"
COPY . .
WORKDIR "/src/src/SnackHub.Payment.Api"
RUN dotnet build "./SnackHub.Payment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SnackHub.Payment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnackHub.Payment.Api.dll"]