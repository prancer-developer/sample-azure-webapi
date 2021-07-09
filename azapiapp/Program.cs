using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace azapiapp
{
    //--------------------------------------------------------------------------------------------------------------
    public class Program
    {
        //----------------------------------------------------------------------------------------------------------
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //----------------------------------------------------------------------------------------------------------
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((context, config) =>
             {
                 var env = context.HostingEnvironment;

             })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                webBuilder.UseStartup<Startup>();
             });
    }
}
