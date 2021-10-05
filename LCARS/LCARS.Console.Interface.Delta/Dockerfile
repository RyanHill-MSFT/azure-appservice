#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LCARS/LCARS.Console.Interface.Delta/LCARS.Console.Interface.Delta.csproj", "LCARS/LCARS.Console.Interface.Delta/"]
COPY ["LCARS/LCARS.Core.Data/LCARS.Core.Data.csproj", "LCARS/LCARS.Core.Data/"]
COPY ["LCARS/LCARS.Core/LCARS.Core.csproj", "LCARS/LCARS.Core/"]
RUN dotnet restore "LCARS/LCARS.Console.Interface.Delta/LCARS.Console.Interface.Delta.csproj"
COPY . .
WORKDIR "/src/LCARS/LCARS.Console.Interface.Delta"
RUN dotnet build "LCARS.Console.Interface.Delta.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LCARS.Console.Interface.Delta.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LCARS.Console.Interface.Delta.dll"]