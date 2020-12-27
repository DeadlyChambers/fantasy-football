
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["*/SCC.FantasyFootball.csproj", "SCC.FantasyFootball/"]
COPY ["*/SCC.FantasyFootball.Business.csproj", "SCC.FantasyFootball.Business/"]
COPY ["*/SCC.FantasyFootball.DTO.csproj", "SCC.FantasyFootball.DTO/"]
COPY ["*/SCC.FantasyFootball.DataAccess.csproj", "SCC.FantasyFootball.DataAccess/"]
COPY ["*/SCC.FantasyFootball.Common.csproj", "SCC.FantasyFootball.Common/"]
RUN dotnet restore "/src/SCC.FantasyFootball/SCC.FantasyFootball.csproj"
COPY . ./

FROM build AS publish
WORKDIR /src/SCC.FantasyFootball
RUN dotnet publish SCC.FantasyFootball.csproj -c Release -o /app/publish --no-restore
#RUN dotnet tool install --global dotnet-ef

#Thought about running some migration updates, but can just do EnsureInits in code
#RUN dotnet ef datebase update --context FootballContext --o SCC.FantasyFootball.DataAccess

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCC.FantasyFootball.dll"]