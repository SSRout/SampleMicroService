#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Transfer.Api/Transfer.Api.csproj", "Transfer.Api/"]
COPY ["Transfer.Data/Transfer.Data.csproj", "Transfer.Data/"]
COPY ["Transfer.Domain/Transfer.Domain.csproj", "Transfer.Domain/"]
COPY ["Domain.Core/Domain.Core.csproj", "Domain.Core/"]
COPY ["InfraIoc/InfraIoc.csproj", "InfraIoc/"]
COPY ["Banking.Domain/Banking.Domain.csproj", "Banking.Domain/"]
COPY ["InfraBus/InfraBus.csproj", "InfraBus/"]
COPY ["Transfer.Application/Transfer.Application.csproj", "Transfer.Application/"]
COPY ["Banking.Data/Banking.Data.csproj", "Banking.Data/"]
COPY ["Banking.application/Banking.application.csproj", "Banking.application/"]
RUN dotnet restore "Transfer.Api/Transfer.Api.csproj"
COPY . .
WORKDIR "/src/Transfer.Api"
RUN dotnet build "Transfer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transfer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transfer.Api.dll"]
