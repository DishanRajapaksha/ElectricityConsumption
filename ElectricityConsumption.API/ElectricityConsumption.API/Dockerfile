FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ElectricityConsumption.API/ElectricityConsumption.API.csproj", "ElectricityConsumption.API/"]
RUN dotnet restore "ElectricityConsumption.API/ElectricityConsumption.API.csproj"
COPY . .
WORKDIR "/src/ElectricityConsumption.API"
RUN dotnet build "ElectricityConsumption.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElectricityConsumption.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElectricityConsumption.API.dll"]