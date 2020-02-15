using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DaLazyDog
{
    public class Program
    {
        private static IWebHostBuilder hostBuilder;
        public static void Main(string[] args)
        {
            hostBuilder = CreateWebHostBuilder(args);
             var dhost = hostBuilder.Build();


            var _loggerFactory = (ILoggerFactory)new LoggerFactory();
            
            AppLogger = _loggerFactory.CreateLogger<Program>();
            dhost.Run();
        }
        public static ILogger<Program> AppLogger;
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
