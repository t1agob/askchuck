FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["askchuck.sln", "./"]
COPY ["askchuck.web/askchuck.web.csproj", "askchuck.web/"]

RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR "/src/askchuck.web"
RUN dotnet build "askchuck.web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "askchuck.web.csproj" -c Release -o /app

FROM base AS final
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "askchuck.web.dll"]
