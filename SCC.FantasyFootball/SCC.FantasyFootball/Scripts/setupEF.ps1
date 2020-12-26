dotnet restore
#cd possibly
#dir possibly
dotnet ef dbcontext scaffold "Host=localhost;Database=postgres;Username=postgres;Password={password}" Npgsql.EntityFrameworkCore.PostgreSQL -o SCC.FantasyFootball.DataAccess


#Identity create migration, then udpate db
dotnet ef migrations add MigrationName --context IdentityContext
dotnet ef database update --context IdentityContext

#OR do it using just the ef commands
add-migration "Migration Name" -Context IdentityContext
update-database -Context IdentityContext

dotnet ef database update --context FootballContext --project .\SCC.FantasyFootball.DataAccess\SCC.FantasyFootball.DataAccess.csproj --startup-project .\SCC.FantasyFootball\SCC.FantasyFootball.csproj --output-dir .\ -t teams -t players -t games -t stats --force
dotnet ef dbContext scaffold "Host=localhost;Database=postgres;Username=postgres;Password=Snowboard1" Npgsql.EntityFrameworkCore.PostgreSQL --context FootballContext --project .\SCC.FantasyFootball.DataAccess\SCC.FantasyFootball.DataAccess.csproj --startup-project .\SCC.FantasyFootball\SCC.FantasyFootball.csproj --output-dir .\ -t teams -t players -t games -t stats --force
dotnet ef database update --context FootballContext --project .\SCC.FantasyFootball.DataAccess\SCC.FantasyFootball.DataAccess.csproj --startup-project .\SCC.FantasyFootball\SCC.FantasyFootball.csproj 

#Docker scripts, might need to get the container name
docker ps
docker images
#docker run -d -p {port into container: port app in container is is using} --name {Any name of the running container you want} {name of the image}
docker run -d -p 8080:80 --name myapp aspnetapp