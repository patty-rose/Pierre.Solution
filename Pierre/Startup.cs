using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pierre.Models;

namespace Pierre
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
          services.AddControllersWithViews();

          services.AddDbContext<PierreContext>(options => options
          .UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));

          services.AddIdentity<ApplicationUser, IdentityRole>()
          .AddRoles<IdentityRole>()
          .AddEntityFrameworkStores<PierreContext>()
          .AddDefaultTokenProviders();

          services.Configure<IdentityOptions>(options =>
          {
          options.Password.RequireDigit = false;
          options.Password.RequiredLength = 0;
          options.Password.RequireLowercase = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireUppercase = false;
          options.Password.RequiredUniqueChars = 0;
          });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection(); //This method causes our server to reroute all traffic to the HTTPS port on our server. This increases application security but it can cause our browser to prevent access to the site and will slow us down when we're developing our project.
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("awaiting..");
      });
        }
    }
}
