# ===== STAGE 1: build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia il file .csproj e ripristina le dipendenze
COPY *.csproj .
RUN dotnet restore

# Copia tutto il resto e compila in modalità release
COPY . .
RUN dotnet publish -c Release -o out

# ===== STAGE 2: runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia i file pubblicati
COPY --from=build /app/out .

# Espone la porta 8080
EXPOSE 8080

# Avvio dell'app
ENTRYPOINT ["dotnet", "CatalogService.dll"]
