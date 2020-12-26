using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCC.FantasyFootball.Areas.Identity.Data;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.Data;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;
using SCC.FantasyFootball.DTO.Profiles;
using System;

namespace SCC.FantasyFootball
{
    public class Startup
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
                SCCPolicies.AddPageSpecificAuth(options);
            });

            
            services.AddAutoMapper((serviceProvider, autoMapper)=>
            {
                autoMapper.AddProfile(new AutoMappingProfile());
                //autoMapper.UseEntityFrameworkCoreModel(serviceProvider);
            }, AppDomain.CurrentDomain.GetAssemblies());

            _ = services.AddDbContext<FootballContext>(options =>
           // options.UseNpgsql(Configuration["ConnectionStrings:sccContext"]));
            options.UseNpgsql(Configuration["Data:DefaultConnection"]));

            ConfigureDI(services);
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
}
