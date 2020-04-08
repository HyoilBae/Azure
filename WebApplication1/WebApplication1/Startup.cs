using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello MSSA");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync($"the requests path was : {context.Request.Path.Value}");
            //});

            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("spongeBob"))
                {
                    await context.Response.WriteAsync($"the SpongeBob value was: {context.Request.Query["spongeBob"]}");
                }
                await context.Response.WriteAsync($"the SpongeBob value was: {context.Request.Path.Value}");
            });

            app.Use(async (context, next) =>    //Use gotta have two inputs (context, next)
            {
                await context.Response.WriteAsync("use middleware \r\n");
                await next.Invoke();
            });
        }
    }
}

