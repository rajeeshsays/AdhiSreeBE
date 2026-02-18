# ==============================
# Stage 1 - Build
# ==============================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore first (for better layer caching)
COPY ["AdhiSreeTransportService.csproj", "./"]
RUN dotnet restore

# Copy everything else and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish

# ==============================
# Stage 2 - Runtime
# ==============================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published files
COPY --from=build /app/publish .

# Expose container port
EXPOSE 8080

# Set environment variable
ENV ASPNETCORE_URLS=http://+:8080

# Start application
ENTRYPOINT ["dotnet", "AdhiSreeTransportService.dll"]
