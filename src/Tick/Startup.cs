using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.UseMvc();
        app.UseFileServer();        
        app.UseSignalR();
        app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!.\nThis is my first demo. This is a ASP.NET vNext test Application on Docker.\n\nMaintained by Ashish Sharma\nEze Software Group");
                
            });
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
          services.AddMvc();
          //services.AddSignalR();
         
         services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
                options.Transports.TransportConnectTimeout = TimeSpan.FromSeconds(50);
            });
    }
}
