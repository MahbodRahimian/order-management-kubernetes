FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY src/Dispatcher.API/Dispatcher.API.csproj src/Dispatcher.API/

RUN dotnet restore src/Dispatcher.API/Dispatcher.API.csproj

COPY src/Dispatcher.API/ src/Dispatcher.API/

RUN dotnet publish src/Dispatcher.API/Dispatcher.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Dispatcher.API.dll"]