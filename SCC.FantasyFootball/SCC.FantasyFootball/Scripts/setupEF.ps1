dotnet restore
#cd possibly
#dir possibly
dotnet ef dbcontext scaffold "Host=localhost;Database=postgres;Username=postgres;Password=Snowboard1" Npgsql.EntityFrameworkCore.PostgreSQL -o SCC.FantasyFootball.DataAccess