FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ElectricityConsumption.Server/ElectricityConsumption.Server.csproj", "ElectricityConsumption.Server/"]
RUN dotnet restore "ElectricityConsumption.Server/ElectricityConsumption.Server.csproj"
COPY . .
WORKDIR "/src/ElectricityConsumption.Server"
RUN dotnet build "ElectricityConsumption.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElectricityConsumption.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectricityConsumption.Server.dll"]