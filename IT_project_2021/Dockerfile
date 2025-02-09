# Use Mono for .NET Framework apps
FROM mono:latest AS build

WORKDIR /src
COPY ./ IT_project_2021/
WORKDIR /src/IT_project_2021

# Restore dependencies
RUN nuget restore IT_project_2021.sln

# Build the project
RUN msbuild IT_project_2021.csproj /p:Configuration=Release /p:Platform="Any CPU" /p:OutputPath=/app/build

# Use Mono runtime for deployment
FROM mono:latest AS runtime
WORKDIR /app
COPY --from=build /app/build .

# Install XSP4 Web Server
RUN apt-get update && apt-get install -y mono-xsp4 && rm -rf /var/lib/apt/lists/*

# Debugging: Show contents of /app
RUN ls -lah /app

# Expose the web server port
EXPOSE 8080

# Ensure XSP4 runs in the foreground
CMD ["xsp4", "--port", "8080", "--root", "/app", "--nonstop"]
