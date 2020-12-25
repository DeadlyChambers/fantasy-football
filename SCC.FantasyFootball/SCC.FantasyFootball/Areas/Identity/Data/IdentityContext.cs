using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.Areas.Identity.Data;

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
                var currentTableName = "_"+builder.Entity(entity.Name).Metadata.GetDefaultTableName().Replace("<string>","");
                builder.Entity(entity.Name).ToTable(currentTableName.ToLower());
            }
            

            //builder.Entity<SCCUser>(entity =>
            //{
            //    entity.ToTable(name: "IdUser");
            //});
            ////builder.Entity<IdentityUser>(entity =>
            ////{
            ////    entity.ToTable(name: "IdUser");
            ////});
            //builder.Entity<IdentityRole>(entity =>
            //{
            //    entity.ToTable(name: "IdRole");
            //});
            //builder.Entity<IdentityUserRole<string>>(entity =>
            //{
            //    entity.ToTable("IdUserRoles");
            //});
            //builder.Entity<IdentityUserClaim<string>>(entity =>
            //{
            //    entity.ToTable("IdUserClaims");
            //});
            //builder.Entity<IdentityUserLogin<string>>(entity =>
            //{
            //    entity.ToTable("IdUserLogins");
            //});
            //builder.Entity<IdentityRoleClaim<string>>(entity =>
            //{
            //    entity.ToTable("IdRoleClaims");
            //});
            //builder.Entity<IdentityUserToken<string>>(entity =>
            //{
            //    entity.ToTable("IdUserTokens");
            //});
          
        }
    }
}
