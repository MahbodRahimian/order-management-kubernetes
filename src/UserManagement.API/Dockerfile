FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY src/UserManagement.API/UserManagement.API.csproj src/UserManagement.API/

RUN dotnet restore src/UserManagement.API/UserManagement.API.csproj

COPY src/UserManagement.API/ src/UserManagement.API/

RUN dotnet publish src/UserManagement.API/UserManagement.API.csproj \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000

EXPOSE 5000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "UserManagement.API.dll"]