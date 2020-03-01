using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryPlanning.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeliveryPlanning
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<DeliveryPlanningContext>(options => options.UseSqlServer(
            //Configuration.GetConnectionString("DeliveryPlanningContextConnection")));

            //services.AddDbContext<DeliveryPlanningContext>(options => options.UseSqlServer(
            //Configuration.GetConnectionString("DeliveryPlanningSQLDBConnection")));

            // Use SQL Database if in Azure, otherwise, use SQLite
            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production")
                services.AddDbContext<DeliveryPlanningContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DeliveryPlanningSQLDBConnection")));
            //else
            //    services.AddDbContext<DeliveryPlanningContext>(options => options.UseSqlServer(
            //    Configuration.GetConnectionString("DeliveryPlanningContextConnection")));

            //    // Automatically perform database migration
                services.BuildServiceProvider().GetService<DeliveryPlanningContext>().Database.Migrate();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
