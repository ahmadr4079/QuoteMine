FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .
WORKDIR /app/QuoteMine/Presentation
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM repo.asax.ir/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/QuoteMine/Presentation/out ./

EXPOSE 8080
ENTRYPOINT ["dotnet", "Presentation.dll"]