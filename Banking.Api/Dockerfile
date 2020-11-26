#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Banking.Api/Banking.Api.csproj", "Banking.Api/"]
COPY ["InfraIoc/InfraIoc.csproj", "InfraIoc/"]
COPY ["Banking.Domain/Banking.Domain.csproj", "Banking.Domain/"]
COPY ["Domain.Core/Domain.Core.csproj", "Domain.Core/"]
COPY ["InfraBus/InfraBus.csproj", "InfraBus/"]
COPY ["Banking.Data/Banking.Data.csproj", "Banking.Data/"]
COPY ["Banking.application/Banking.application.csproj", "Banking.application/"]
RUN dotnet restore "Banking.Api/Banking.Api.csproj"
COPY . .
WORKDIR "/src/Banking.Api"
RUN dotnet build "Banking.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Banking.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Banking.Api.dll"]