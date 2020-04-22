using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace PersonalManagementServicePOC.SelfHosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json")
                                 .AddJsonFile("hosting.json", optional: true)
                                 .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                //.UseApplicationInsights()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }


        //public static void Main(string[] args)
        //{
        //    CreateWebHostBuilder(args).Build().Run();
        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>            
        //    WebHost.CreateDefaultBuilder(args)

        //    //.ConfigureKestrel(serveroptions => { })
        //    .UseStartup<Startup>()
        //    .UseIISIntegration()
        //    .UseKestrel()
        //    .UseContentRoot(Directory.GetCurrentDirectory())
        //    //.ConfigureLogging(a=> { })
        //    ;
    }
}
