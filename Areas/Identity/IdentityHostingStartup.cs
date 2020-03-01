using System;
using DeliveryPlanning.Areas.Identity.Data;
using DeliveryPlanning.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DeliveryPlanning.Areas.Identity.IdentityHostingStartup))]
namespace DeliveryPlanning.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DeliveryPlanningContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DeliveryPlanningContextConnection")));

                services.AddDefaultIdentity<DeliveryPlanningUser>()
                    .AddEntityFrameworkStores<DeliveryPlanningContext>();
            });
        }
    }
}