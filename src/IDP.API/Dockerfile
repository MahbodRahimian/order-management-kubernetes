FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY src/IDP.API/IDP.API.csproj src/IDP.API/

RUN dotnet restore src/IDP.API/IDP.API.csproj

COPY src/IDP.API/ src/IDP.API/

RUN dotnet publish src/IDP.API/IDP.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "IDP.API.dll"]