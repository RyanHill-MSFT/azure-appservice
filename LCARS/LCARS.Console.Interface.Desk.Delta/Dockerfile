#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ["LCARS/LCARS.Core/LCARS.Core.csproj", "LCARS/LCARS.Core/"]
COPY ["LCARS/LCARS.Core.Data/LCARS.Core.Data.csproj", "LCARS/LCARS.Core.Data/"]
COPY ["LCARS/LCARS.Console.Interface.Desk.Delta/LCARS.Console.Interface.Desk.Delta.csproj", "LCARS/LCARS.Console.Interface.Desk.Delta/"]
RUN dotnet restore "LCARS/LCARS.Console.Interface.Desk.Delta/LCARS.Console.Interface.Desk.Delta.csproj"

COPY ["LCARS/LCARS.Core//", "LCARS/LCARS.Core/"]
COPY ["LCARS/LCARS.Core.Data//", "LCARS/LCARS.Core.Data/"]
COPY ["LCARS/LCARS.Console.Interface.Desk.Delta//", "LCARS/LCARS.Console.Interface.Desk.Delta/"]
WORKDIR "/source/LCARS/LCARS.Console.Interface.Desk.Delta"
RUN dotnet build "LCARS.Console.Interface.Desk.Delta.csproj" -c release --no-restore

FROM build as publish
RUN dotnet publish -c release --no-build -o /app

FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=publish /app ./
ENTRYPOINT ["dotnet", "LCARS.Console.Interface.Desk.Delta.dll"]
