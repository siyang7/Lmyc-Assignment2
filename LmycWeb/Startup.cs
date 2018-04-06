using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LmycWeb.Data;
using LmycWeb.Models;
using LmycWeb.Services;

namespace LmycWeb
{
    public class Startup
    {
        private IConfiguration config;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("appsettings.json");
            config = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            /*
            ApplicationUser user = new ApplicationUser();
            user.UserName = "a@a.a";
            user.Email = "a@a.a";
            user.FirstName = "Bob";
            user.LastName = "Smith";
            user.Street = "Main St";
            user.City = "Vancouver";
            user.Province = "BC";
            user.PostalCode = "V5V 1J6";
            user.Country = "Canada";
            user.MobilePhone = "604-222-1111";
            user.SailingExperience = "medium";

            IdentityResult result = userManager.CreateAsync(user, "P@$$w0rd").Result;

            if (result.Succeeded)
            {
                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Admin";
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                    if (roleResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
            }
            */

        }
    }
}
