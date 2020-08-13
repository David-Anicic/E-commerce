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
using EP2_2.Data;
using EP2_2.Models;
using EP2_2.Services;
using EP2_2.UI;
using EP2_2.UI.Interfaces;
using EP2_2.BL.Interfaces;
using EP2_2.BL;
using EP2_2.DAL;
using EP2_2.DAL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EP2_2
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IProductUI, ProductUI>();
            services.AddTransient<IProductBL, ProductBL>();
            services.AddTransient<IProductDAL, ProductDAL>();

            services.AddTransient<ICategoryUI, CategoryUI>();
            services.AddTransient<ICategoryBL, CategoryBL>();
            services.AddTransient<ICategoryDAL, CategoryDAL>();

            services.AddTransient<IShoppingCartUI, ShoppingCartUI>();
            services.AddTransient<IShoppingCartBL, ShoppingCartBL>();
            services.AddTransient<IShoppingCartDAL, ShoppingCartDAL>();

            services.AddTransient<IOrderUI, OrderUI>();
            services.AddTransient<IOrderBL, OrderBL>();
            services.AddTransient<IOrderDAL, OrderDAL>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
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

            app.UseSession();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            try
            {
                CreateRoles(service).Wait();
            }
            catch (Exception)
            {
               
            }

        }

        private async Task CreateRoles(IServiceProvider service)
        {
            var RoleManager = service.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var poweruser = new ApplicationUser
            {
                UserName = "Administrator@gmail.com",
                Email = "Administrator@gmail.com"
            };

            var _user = await UserManager.FindByEmailAsync(poweruser.Email);
            if (_user == null)
            {
                var createdPoweruser = await UserManager.CreateAsync(poweruser, "Lozinka1#");
                if (createdPoweruser.Succeeded)
                {
                    await UserManager.AddToRoleAsync(poweruser, "Admin");
                }
            }

        }
    }
}
