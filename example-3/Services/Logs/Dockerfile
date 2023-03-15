FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./Services/Logs/Logs.csproj ./Services/Logs/
COPY ./Libs/Broker/Broker.csproj ./Libs/Broker/
COPY ./Libs/Contracts/Contracts.csproj ./Libs/Contracts/

RUN dotnet restore ./Services/Logs/Logs.csproj

COPY ./Services/Logs/ ./Services/Logs/
COPY ./Libs/Broker/ ./Libs/Broker/
COPY ./Libs/Contracts/ ./Libs/Contracts/

WORKDIR ./Services/Logs
RUN dotnet build Logs.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Logs.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Logs.dll"]
