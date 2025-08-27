# ===== RUNTIME =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# ===== SDK (BUILD) =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj riêng lẻ để cache restore
COPY ["WebAPIDeployment/WebAPIDeployment.csproj", "WebAPIDeployment/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["DAL/DAL.csproj", "DAL/"]

# Restore dependencies
RUN dotnet restore "WebAPIDeployment/WebAPIDeployment.csproj"

# Copy toàn bộ source
COPY . .

WORKDIR "/src/WebAPIDeployment"
RUN dotnet build -c Release -o /app/build

# ===== PUBLISH =====
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ===== FINAL IMAGE =====
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPIDeployment.dll"]
