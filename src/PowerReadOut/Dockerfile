FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PowerReadOut/PowerReadOut.csproj", "PowerReadOut/"]
RUN dotnet restore "PowerReadOut/PowerReadOut.csproj"
COPY . .
WORKDIR "/src/PowerReadOut"
RUN dotnet build "PowerReadOut.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerReadOut.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerReadOut.dll"]
