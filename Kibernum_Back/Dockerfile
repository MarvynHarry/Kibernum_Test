# Use the official .NET SDK image to build the backend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything and restore dependencies
COPY . ./
RUN dotnet restore

# Build the backend application
RUN dotnet publish -c Release -o out

# Use a smaller runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port the backend will listen on
EXPOSE 5000

# Command to run the application
ENTRYPOINT ["dotnet", "Kibernum_Back.dll"]
