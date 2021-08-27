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
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(opt =>
                    {
                        opt.AddServerHeader = false;
                        opt.ConfigureHttpsDefaults(s =>
                        {
                            s.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13; ;
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                    //webBuilder
                    //.ConfigureKestrel(o => o.AddServerHeader = false)
                    //// hide Kestrel server header
                    ////.UseKestrel()
                    ////.UseContentRoot(Directory.GetCurrentDirectory())
                    //.UseIISIntegration()
                    //.UseStartup<Startup>();
                    //webBuilder.UseKestrel(kestrelOptions =>
                    //    {
                    //////        opt.AddServerHeader = false;
                    //        kestrelOptions.ConfigureHttpsDefaults(httpsOptions =>
                    //        {
                    //            httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
                    //        });
                    //    });

                    //webBuilder.ConfigureHttpsDefaults(httpsOptions =>
                    //    {
                    //        httpsOptions.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
                    //    });
                    //});

                    //webBuilder.UseConfiguration(httpsOption =>
                    //{
                    //    httpsOption.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13;
                    //});
                    ////webBuilder.UseKestrel(opt =>
                    ////{
                    ////    opt.AddServerHeader = false;
                    ////    opt.ConfigureHttpsDefaults(s =>
                    ////    {
                    ////        s.SslProtocols = SslProtocols.Tls12;
                    ////    });
                    ////});

                    //////////////////////////

                    ////webBuilder.ConfigureKestrel(o => o.AddServerHeader = false)
                    ////// hide Kestrel server header
                    //////.UseKestrel()
                    ////.UseContentRoot(Directory.GetCurrentDirectory())
                    ////.UseIISIntegration()
                    ////.UseStartup<Startup>();

                });
    }
}
