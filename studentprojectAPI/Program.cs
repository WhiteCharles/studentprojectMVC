// repos\studentprojectMVC\studentprojectMVC\studentprojectAPI\
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using studentprojectAPI.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectAPI
{
//#pragma warning disable CS1591
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
                    webBuilder.UseStartup<Startup>();
                });
   
    }
#pragma warning restore CS1591
}


////public class Program
////{
////    public static void Main(string[] args)
////    {
////        CreateHostBuilder(args).Build().Run();
////    }

////    public static IHostBuilder CreateHostBuilder(string[] args) =>
////        Host.CreateDefaultBuilder(args)
////            .ConfigureWebHostDefaults(webBuilder =>
////            {
////            webBuilder.UseKestrel(opt =>
////            {
////                opt.AddServerHeader = false;
////                opt.ConfigureHttpsDefaults(s =>
////                {
////                    s.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13; ;
////                });
////            });
////            webBuilder.UseStartup<Startup>();

// *********
//public static void Main(string[] args)
//{
//    var host = CreateHostBuilder(args).Build();

//    // migrate the database.  Best practice = in Main, using service scope
//    using (var scope = host.Services.CreateScope())
//    {
//        try
//        {
//            var context = scope.ServiceProvider.GetService<AppDbContext>();
//            // for demo purposes, delete the database & migrate on startup so 
//            // we can start with a clean slate
//            context.Database.EnsureDeleted();
//            context.Database.Migrate();
//        }
//        catch (Exception ex)
//        {
//            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
//            logger.LogError(ex, "An error occurred while migrating the database.");
//        }
//    }

//    // run the web app
//    host.Run();
//}
