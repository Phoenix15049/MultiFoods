#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MultiFoods-Backend/MultiFoods-Backend.csproj", "MultiFoods-Backend/"]
RUN dotnet restore "./MultiFoods-Backend/./MultiFoods-Backend.csproj"
COPY . .
WORKDIR "/src/MultiFoods-Backend"
RUN dotnet build "./MultiFoods-Backend.csproj" -c Release -o /app/build

# Publish Stage
FROM build AS publish
RUN dotnet publish "./MultiFoods-Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Install PostgreSQL client libraries
RUN apt-get update \
    && apt-get install -y --no-install-recommends libpq-dev \
    && rm -rf /var/lib/apt/lists/*

# Copy published files
COPY --from=publish /app/publish .

# Set environment variables for PostgreSQL connection
ENV ConnectionStrings__DefaultConnection "Host=localhost;Port=1382;Database=MultiFoodsBeta;Username=postgres;Password=09331318893"

# Set the user for the application
USER app

# Start the application
ENTRYPOINT ["dotnet", "MultiFoods-Backend.dll"]
