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
