#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Event/EventService/EventService.csproj", "src/Event/EventService/"]
COPY ["src/Common/Common.Infrastructure.Implementation/Common.Infrastructure.Implementation.csproj", "src/Common/Common.Infrastructure.Implementation/"]
COPY ["src/Common/Common.Infrastructure.Interface/Common.Infrastructure.Interface.csproj", "src/Common/Common.Infrastructure.Interface/"]
COPY ["src/Event/Event.Infrastructure/Event.Infrastructure.csproj", "src/Event/Event.Infrastructure/"]
COPY ["src/Event/Event.Domain/Event.Domain.csproj", "src/Event/Event.Domain/"]
COPY ["src/Common/Common/Common.csproj", "src/Common/Common/"]
COPY ["src/Event/Event.Logic/Event.Logic.csproj", "src/Event/Event.Logic/"]
COPY ["src/Common/Common.Persistance.EFCore/Common.Persistance.EFCore.csproj", "src/Common/Common.Persistance.EFCore/"]
RUN dotnet restore "src/Event/EventService/EventService.csproj"
COPY . .
WORKDIR "/src/src/Event/EventService"
RUN dotnet build "EventService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventService.dll"]
