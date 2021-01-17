#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MosarticoApi/MosarticoApi.csproj", "MosarticoApi/"]
RUN dotnet restore "MosarticoApi/MosarticoApi.csproj"
COPY . .
WORKDIR "/src/MosarticoApi"
RUN dotnet build "MosarticoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MosarticoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MosarticoApi.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.1