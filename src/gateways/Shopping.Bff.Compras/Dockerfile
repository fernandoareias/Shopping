#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/gateways/Shopping.Bff.Compras/NSE.Bff.Compras.csproj", "src/gateways/Shopping.Bff.Compras/"]
RUN dotnet restore "src/api gateways/Shopping.Bff.Compras/Shopping.Bff.Compras.csproj"
COPY . .
WORKDIR "/src/src/gateways/Shopping.Bff.Compras"
RUN dotnet build "Shopping.Bff.Compras.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shopping.Bff.Compras.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shopping.Bff.Compras.dll"]