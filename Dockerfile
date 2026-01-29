# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos el csproj y restauramos
COPY ["src/ApiBootcampClt.Api/ApiBootcampClt.Api.csproj", "src/ApiBootcampClt.Api/"]
RUN dotnet restore "src/ApiBootcampClt.Api/ApiBootcampClt.Api.csproj"

# Copiamos el resto del código
COPY . .
RUN dotnet build "src/ApiBootcampClt.Api/ApiBootcampClt.Api.csproj" -c Release -o /app/build

# =========================
# PUBLISH
# =========================
FROM build AS publish
RUN dotnet publish "src/ApiBootcampClt.Api/ApiBootcampClt.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

EXPOSE 8080

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiBootcampClt.Api.dll"]