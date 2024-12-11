# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy everything and build
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Use the .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expose port 5000 for HTTP and 5001 for HTTPS
EXPOSE 5000 5001

# Run the application
ENTRYPOINT ["dotnet", "backend.dll"]