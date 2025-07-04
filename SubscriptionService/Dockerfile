FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Install EF Core CLI
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy only csproj
# COPY ./SubscriptionService.csproj ./ 

COPY . .

# Restore dependencies
RUN dotnet restore "./SubscriptionService.csproj"

# Copy the rest of the app
# COPY . .

# Set working directory to the app folder (where Program.cs is)
WORKDIR /src

# Build the project
RUN dotnet build "SubscriptionService.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "SubscriptionService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SubscriptionService.dll"]
