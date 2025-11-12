# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# сначала копируем только csproj, чтобы кешировалось
COPY LoginTest/LoginTest.csproj ./LoginTest/
RUN dotnet restore ./LoginTest/LoginTest.csproj

# теперь копируем весь код
COPY . .
WORKDIR /src/LoginTest
RUN dotnet publish -c Release -o /app

# Этап запуска
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "LoginTest.dll"]
