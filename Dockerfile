#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AuthGuard.Api/AuthGuard.Api.csproj", "src/AuthGuard.Api/"]
COPY ["src/AuthGuard.Application/AuthGuard.Application.csproj", "src/AuthGuard.Application/"]
COPY ["src/AuthGuard.Domain/AuthGuard.Domain.csproj", "src/AuthGuard.Domain/"]
COPY ["src/AuthGuard.Infrastructure/AuthGuard.Infrastructure.csproj", "src/AuthGuard.Infrastructure/"]
COPY ["src/AuthGuard.EntityFrameworkCore/AuthGuard.EntityFrameworkCore.csproj", "src/AuthGuard.EntityFrameworkCore/"]
RUN dotnet restore "src/AuthGuard.Api/AuthGuard.Api.csproj"
COPY . .
WORKDIR "/src/src/AuthGuard.Api"
RUN dotnet build "AuthGuard.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthGuard.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthGuard.Api.dll"]