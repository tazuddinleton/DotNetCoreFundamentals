using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTaskManager.Data.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using SimpleTaskManager.Data.Repositories;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Google;
using SimpleTaskManager.Web.Common;

namespace SimpleTaskManager.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // By setting the AuthorizeFilter as global filter
            // We are making sure every controller and actions are secured by default
            services.AddControllersWithViews(x => x.Filters.Add(new AuthorizeFilter()));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<TaskManagerContext>(option =>
            {
                option.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(TaskManagerContext).Assembly.FullName)
                    );
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie( o => o.Events.OnValidatePrincipal = async (c) => {
                if (!c.Principal.IsActiveAccount(services))
                    c.RejectPrincipal();
            })
            .AddGoogle(o =>
            {
                o.ClientId = Configuration["google:client_id"];
                o.ClientSecret = Configuration["google:client_secret"];                
            });
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
         
                endpoints.MapControllerRoute("Default", "{Controller=Task}/{Action=Index}/{id?}");
            });
        }
    }
}
