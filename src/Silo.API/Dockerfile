FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY src/Silo.API/Silo.API.csproj src/Silo.API/

RUN dotnet restore src/Silo.API/Silo.API.csproj

COPY src/Silo.API/ src/Silo.API/

RUN dotnet publish src/Silo.API/Silo.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Silo.API.dll"]