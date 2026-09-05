FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY src/OrderManagement.API/OrderManagement.API.csproj src/OrderManagement.API/

RUN dotnet restore src/OrderManagement.API/OrderManagement.API.csproj

COPY src/OrderManagement.API/ src/OrderManagement.API/

RUN dotnet publish src/OrderManagement.API/OrderManagement.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "OrderManagement.API.dll"]