FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MayraPlatform.WebAPI/MayraPlatform.WebAPI.csproj", "MayraPlatform.WebAPI/"]
RUN dotnet restore "MayraPlatform.WebAPI/MayraPlatform.WebAPI.csproj"
COPY . .
WORKDIR "/src/MayraPlatform.WebAPI"
RUN dotnet build "MayraPlatform.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MayraPlatform.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MayraPlatform.WebAPI.dll"]
