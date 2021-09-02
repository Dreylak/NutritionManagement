#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Customer/CustomerService/CustomerService.csproj", "src/Customer/CustomerService/"]
COPY ["src/Customer/Logic/Logic.csproj", "src/Customer/Logic/"]
COPY ["src/Customer/Domain/Domain.csproj", "src/Customer/Domain/"]
COPY ["src/Common/Common/Common.csproj", "src/Common/Common/"]
COPY ["src/Common/Common.Infrastructure.Interface/Common.Infrastructure.Interface.csproj", "src/Common/Common.Infrastructure.Interface/"]
COPY ["src/Common/Common.Infrastructure.Implementation/Common.Infrastructure.Implementation.csproj", "src/Common/Common.Infrastructure.Implementation/"]
COPY ["src/Customer/Infrastructure/Infrastructure.csproj", "src/Customer/Infrastructure/"]
COPY ["src/Common/Common.Persistance.EFCore/Common.Persistance.EFCore.csproj", "src/Common/Common.Persistance.EFCore/"]
RUN dotnet restore "src/Customer/CustomerService/CustomerService.csproj"
COPY . .
WORKDIR "/src/src/Customer/CustomerService"
RUN dotnet build "CustomerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerService.dll"]
