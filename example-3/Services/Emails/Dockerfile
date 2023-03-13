FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./Services/Emails/Emails.csproj ./Services/Emails/
COPY ./Libs/Broker/Broker.csproj ./Libs/Broker/
COPY ./Libs/Contracts/Contracts.csproj ./Libs/Contracts/

RUN dotnet restore ./Services/Emails/Emails.csproj

COPY ./Services/Emails/ ./Services/Emails/
COPY ./Libs/Broker/ ./Libs/Broker/
COPY ./Libs/Contracts/ ./Libs/Contracts/

WORKDIR ./Services/Emails
RUN dotnet build Emails.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish Emails.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Emails.dll"]
