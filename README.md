# QuoteMine

### Requirements Start Application
- Docker
- Docker Compose


### Project Startup
```bash
> docker pull mcr.microsoft.com/dotnet/sdk:8.0
> docker pull mcr.microsoft.com/dotnet/aspnet:8.0
> docker pull redis:alpine
> docker network create quoteminenet
> docker volume create local-services-cache-data
> docker compose -f docker-compose-services.yml up -d
> docker build . -t "quotemine":"latest"
> docker compose -f docker-compose.yml up -d
```