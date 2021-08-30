#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY *.csproj .
RUN dotnet restore

COPY . .
WORKDIR /source/LCARS.Console.Interface.Desk.Delta
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "LCARS.Console.Interface.Desk.Delta.dll"]
