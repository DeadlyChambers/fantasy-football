using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

                services.AddIdentity<SCCUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }).AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<IdentityContext>();

                //services.AddDefaultIdentity<SCCUser>();
            });
        }
    }
}