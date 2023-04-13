FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
FROM debian:stable-slim
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Pets-Store.csproj", "."]
RUN dotnet restore "./Pets-Store.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Pets-Store.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Pets-Store.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pets-Store.dll"]