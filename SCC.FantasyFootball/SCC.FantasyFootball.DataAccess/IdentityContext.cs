using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DataAccess.Extensions;
using System;
using System.Linq;

namespace SCC.FantasyFootball.Data
{
    public class IdentityContext : IdentityDbContext<SCCUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder
       .UseSnakeCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Ensure the Roles are statically loaded
            var roles = Enum.GetValues<SCCRoles>().Select(x => x.AsIdentityRole()).ToArray();

            builder.Entity<IdentityRole>(e => e.HasData(roles));

            // PostgreSQL uses the public schema by default - not dbo.
            builder.HasDefaultSchema("public");
            base.OnModelCreating(builder);

            //Rename Identity tables to lowercase
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                if (entity.Name == "IdentityUser")
                    continue;
                var currentTableName = "_" + builder.Entity(entity.Name).Metadata.GetDefaultTableName().Replace("<string>", "");
                builder.Entity(entity.Name).ToTable(currentTableName.ToLower());
            }

        }
    }
}
