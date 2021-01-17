#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MosarticoApi/MosarticoApi.csproj", "MosarticoApi/"]
COPY ["MosarticoApi.Application/MosarticoApi.Application.csproj", "MosarticoApi.Application/"]
COPY ["MosarticoApi.Domain/MosarticoApi.Domain.csproj", "MosarticoApi.Domain/"]
COPY ["MosarticoApi.Application.DTO/MosarticoApi.Application.DTO.csproj", "MosarticoApi.Application.DTO/"]
COPY ["MosarticoApi.Infrastructure.CrossCutting.Util/MosarticoApi.Infrastructure.CrossCutting.Util.csproj", "MosarticoApi.Infrastructure.CrossCutting.Util/"]
COPY ["MosarticoApi.Domain.Core/MosarticoApi.Domain.Core.csproj", "MosarticoApi.Domain.Core/"]
COPY ["MosarticoApi.Infrastructure.CrossCutting.IOC/MosarticoApi.Infrastructure.CrossCutting.IOC.csproj", "MosarticoApi.Infrastructure.CrossCutting.IOC/"]
COPY ["MosarticoApi.Infrastructure.Repository/MosarticoApi.Infrastructure.Repository.csproj", "MosarticoApi.Infrastructure.Repository/"]
COPY ["MosarticoApi.Infrastructure.Data/MosarticoApi.Infrastructure.Data.csproj", "MosarticoApi.Infrastructure.Data/"]
COPY ["Mosartico.Domain.Services/MosarticoApi.Domain.Services.csproj", "Mosartico.Domain.Services/"]
RUN dotnet restore "MosarticoApi/MosarticoApi.csproj"
COPY . .
WORKDIR "/src/MosarticoApi"
RUN dotnet build "MosarticoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MosarticoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN  useradd -m idollynho
USER idollynho

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet MosarticoApi.dll
