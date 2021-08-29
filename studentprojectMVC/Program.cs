using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
// repos\studentprojectMVC\studentprojectMVC\studentprojectMVC\studentprojectMVC.csproj
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace studentprojectMVC
{
    public class Program
    {
        public static void Main(string[] args) //  entry point
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(opt =>  // .UseKestrel
                    {
                        opt.ConfigureHttpsDefaults(s =>
                        {
                            s.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13; ;
                        });
                        opt.AddServerHeader = false;
                    });
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseStartup<Startup>();
                });
    }
}
