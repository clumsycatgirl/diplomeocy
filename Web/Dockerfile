FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Web/Web.csproj Web/
COPY Game/Game.csproj Game/
RUN dotnet restore Web/Web.csproj

COPY . .
RUN dotnet publish Web/Web.csproj -c Release -o /app/published --no-restore
RUN ls 

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/published .

EXPOSE 5000
ENTRYPOINT ["dotnet", "Web.dll"]
