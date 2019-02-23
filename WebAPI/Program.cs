using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                          optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
            }).CaptureStartupErrors(true)
            .UseStartup<Startup>()
            .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
