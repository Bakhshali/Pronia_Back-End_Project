using BackEnd_1.Task.DAL;
using BackEnd_1.Task.Models;
using BackEnd_1.Task.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_1.Task
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        { 
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<LayoutService>();

            services.AddControllersWithViews();

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(_configuration.GetConnectionString("Default"));
            });

            

            services.AddHttpContextAccessor();


            services.AddIdentity<AppUser,IdentityRole>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = true;
                option.Password.RequireDigit = true;
                option.Password.RequireNonAlphanumeric = false;

                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                option.Lockout.AllowedForNewUsers = true;

                option.SignIn.RequireConfirmedEmail = false;

                option.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm_1234567890";

            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
