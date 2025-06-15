FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY TicketService/TicketService.csproj TicketService/
COPY TicketService.DAL/TicketService.DAL.csproj TicketService.DAL/
COPY TicketService.BL/TicketService.BL.csproj TicketService.BL/
COPY TicketService.ApiClient/TicketService.ApiClient.csproj TicketService.ApiClient/
COPY TicketService.Models/TicketService.Models.csproj TicketService.Models/
COPY TicketService.Migrations/TicketService.Migrations.csproj TicketService.Migrations/
COPY TicketService.sln .


RUN dotnet restore TicketService.sln
COPY . .

RUN dotnet publish TicketService/TicketService.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "TicketService.dll"]
