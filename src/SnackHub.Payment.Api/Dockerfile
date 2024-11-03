#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
ARG PASSWORD_ENV_SEEDED
ENV PASSWORD_ENV_SEEDED=$PASSWORD_ENV_SEEDED
RUN dotnet dev-certs https -ep /src/aspnetapp.pfx -p ${PASSWORD_ENV_SEEDED}

COPY ["src/SnackHub.Payment.Api/SnackHub.Payment.Api.csproj", "src/SnackHub.Payment.Api/"]
COPY ["src/SnackHub.Payment.Ioc/SnackHub.Payment.Ioc.csproj", "src/SnackHub.Payment.Ioc/"]
COPY ["src/SnackHub.Payment.Application/SnackHub.Payment.Application.csproj", "src/SnackHub.Payment.Application/"]
COPY ["src/SnackHub.Payment.Domain/SnackHub.Payment.Domain.csproj", "src/SnackHub.Payment.Domain/"]
RUN dotnet restore "./src/SnackHub.Payment.Api/./SnackHub.Payment.Api.csproj"
COPY . .
WORKDIR "/src/src/SnackHub.Payment.Api"
RUN dotnet build "./SnackHub.Payment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SnackHub.Payment.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/aspnetapp.pfx .
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN chown -R www-data:www-data /app
USER www-data

ENTRYPOINT ["dotnet", "SnackHub.Payment.Api.dll"]