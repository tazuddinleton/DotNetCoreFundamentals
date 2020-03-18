using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SimplestNetCoreApp
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app) 
        {


            app.UseMvc();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World");
                Console.WriteLine("Hello ");
            });
        }
    }
}
