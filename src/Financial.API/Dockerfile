FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY src/Financial.API/Financial.API.csproj src/Financial.API/

RUN dotnet restore src/Financial.API/Financial.API.csproj

COPY src/Financial.API/ src/Financial.API/

RUN dotnet publish src/Financial.API/Financial.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Financial.API.dll"]