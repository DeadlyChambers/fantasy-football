using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCC.FantasyFootball.Areas.Identity.Data;
using SCC.FantasyFootball.Data;

[assembly: HostingStartup(typeof(SCC.FantasyFootball.Areas.Identity.IdentityHostingStartup))]
namespace SCC.FantasyFootball.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseNpgsql(
                        context.Configuration["ConnectionStrings:sccContext"]));

                services.AddDefaultIdentity<SCCUser>(options => 
                { options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false; 
                    options.Password.RequireLowercase = false; 
                    options.Password.RequireNonAlphanumeric = false; })
                .AddRoles<IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}