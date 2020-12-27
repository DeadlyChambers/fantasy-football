using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.Data;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DataAccess.Configuration;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.DTO.Profiles;
using System;
using System.Linq;

namespace SCC.FantasyFootball
{
    public class Startup : StartupDb
    {        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddAuthorization();
            services.AddRazorPages().AddRazorPagesOptions(options =>
            {
                AddPageSpecificAuth(options);
            });
            services.AddAutoMapper((serviceProvider, autoMapper) =>
            {
                autoMapper.AddProfile(new AutoMappingProfile());
                //autoMapper.UseEntityFrameworkCoreModel(serviceProvider);
            }, AppDomain.CurrentDomain.GetAssemblies());

            var conn = Environment.ExpandEnvironmentVariables(Configuration["Data:DefaultConnection"]);


            services.AddSingleton(provider =>
            {
                var service = provider.GetRequiredService<ILogger<StartupLogger>>();
                return new StartupLogger(service);
            });
            var logger = services.BuildServiceProvider().GetRequiredService<StartupLogger>();
            HandleApplicationVersioning(logger);

            logger.Log($"In startup the connstring is {conn}");
            ConnectionString = conn;
            _ = services.AddDbContext<FootballContext>(options =>
                options.UseNpgsql(conn))
                .AddDbContext<IdentityContext>(options =>
                    options.UseNpgsql(conn));
            services.AddIdentity<SCCUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders()
            .AddDefaultUI()
            .AddEntityFrameworkStores<IdentityContext>();


            ConfigureDI(services);

        }

        /// <summary>
        /// Silly method to help display Build Version, Deploy Version, and App Version that
        /// is incremented every build, is now being done by autoincrement_version.ps1
        /// </summary>
        private void HandleApplicationVersioning(StartupLogger logger)
        {
            try
            {
                var coreVersion = Configuration["Data:AppVersion"];
                AppVersion = coreVersion.ToString();
                var x = 1;

                foreach (var clArg in Environment.GetCommandLineArgs())
                {
                    if (clArg.Equals("-version", StringComparison.OrdinalIgnoreCase))
                    {
                        CICDVersion = Environment.GetCommandLineArgs()[x];
                    }
                    x++;
                }
                logger.Log($"Command Parameters passed as args {string.Join(",", Environment.GetCommandLineArgs().Select(x => x))}");
                var version = AppVersion.Split('.');
                if (string.IsNullOrEmpty(CICDVersion))
                    CICDVersion = $"{version[0]}.{version[1]}.{Configuration["Data:CICDVersion"]}";
                AppVersion = CICDVersion + "." + AppVersion.Split('.')[3];
            }
            catch (Exception e)
            {
                //don't really care about this if it fails
            }
        }

        /// <summary>
        /// Set the individual page, folders, or areas to have policies enforced for Auth
        /// </summary>
        /// <param name="options"></param>
        public void AddPageSpecificAuth(RazorPagesOptions options)
        {
            ////Admin can delete and edit
            //options.Conventions.AuthorizePage("/Teams/Delete", SCCPolicies.Updaters);
            //options.Conventions.AuthorizePage("/Teams/Edit", SCCPolicies.Updaters);
            ////Trusted can create
            //options.Conventions.AuthorizePage("/Teams/Create", SCCPolicies.Creators);
            ////Account can view
            //options.Conventions.AuthorizePage("/Teams/Details", SCCPolicies.Readers);
            //Anonymous can view all indexes
            //options.Conventions.AllowAnonymousToPage("~/Index");
            //Execpt stats

            options.Conventions.AllowAnonymousToAreaPage("Identity", "/Account/AccessDenied");
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        /// <summary>
        /// Setup the various custom DI impleminations/interfaces
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureDI(IServiceCollection services)
        {
            services.AddTransient<IEntitiesManager<TeamDto>, BasicEntitiesManager<TeamDto>>();
            services.AddTransient<IEntitiesManager<PlayerDto>, BasicEntitiesManager<PlayerDto>>();
            services.AddTransient<IEntitiesManager<GameDto>, BasicEntitiesManager<GameDto>>();
            services.AddTransient<IMultiEntitiesManager<StatDto>, StatsManager<StatDto>>();
        }
    }

    /// <summary>
    /// Simple logger specifically for Startup logging
    /// </summary>
    public class StartupLogger
    {
        private readonly ILogger _logger;

        public StartupLogger(ILogger<StartupLogger> logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
