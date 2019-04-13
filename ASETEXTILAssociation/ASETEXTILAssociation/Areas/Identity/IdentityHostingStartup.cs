using System;
using ASETEXTILAssociation.Data;
using ASETEXTILAssociation.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ASETEXTILAssociation.Areas.Identity.IdentityHostingStartup))]
namespace ASETEXTILAssociation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ASETEXTILAssociationContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<AContext>();
            });
        }
    }
}