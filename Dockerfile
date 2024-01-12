# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the entire project directory
COPY . .

# Restore dependencies
RUN dotnet restore

# Continue with the remaining build steps
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:latest

WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/out .

# Expose the port the app will run on
EXPOSE 80

# Command to run the application
ENTRYPOINT ["dotnet", "RainfallApi.Web.dll"]
