using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCC.FantasyFootball.Business.Managers;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddRazorPages();

            services.AddAutoMapper((serviceProvider, autoMapper)=>
            {
                autoMapper.AddProfile(new AutoMappingProfile());
                //autoMapper.UseEntityFrameworkCoreModel(serviceProvider);
            }, AppDomain.CurrentDomain.GetAssemblies());

            _ = services.AddDbContext<FootballContext>(options =>
            options.UseNpgsql(Configuration["ConnectionStrings:sccContext"]));

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
            services.AddTransient<ITeamsManager, TeamsManager>();
        }
    }
}
