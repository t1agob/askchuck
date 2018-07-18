FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["askchuck.sln", "./"]
COPY ["askchuck.api/askchuck.api.csproj", "askchuck.api/"]

RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR "/src/askchuck.api"
RUN dotnet build "askchuck.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "askchuck.api.csproj" -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "askchuck.api.dll"]
