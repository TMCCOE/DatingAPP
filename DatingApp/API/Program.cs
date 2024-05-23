using API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using API;

public partial class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();

        // TODO: Configure IIS here to only listen on HTTPS. That way, connections over 80 (HTTP) will be rejected and any sensitive 
        // information a client sends over HTTP is not intercepted
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureKestrel((context, options) =>
        {
            // TODO: Whatever settings when running in OutOfProcess mode (when Kestrel is being used as web server)
            // See the TrainingCenter.Api project file source and https://weblog.west-wind.com/posts/2019/Mar/16/ASPNET-Core-Hosting-on-IIS-with-ASPNET-Core-22#checking-for-inprocess-or-outofprocess-hosting

            // When errors are not being logged, configure UseConnectionLogging, in the API project file source set to OutOfProcess and in the EC2 instance
            // create a folder called \logs here: C:\inetpub\AspNetCoreWebApps\app. Give DefaultAppPool full rights on the folder so logs can be written.
            // Run tests and look here for low-leve logging details.

            //options.ConfigureEndpointDefaults(listenOptions =>
            //{
            //    listenOptions.UseConnectionLogging();
            //});
        })
        .ConfigureAppConfiguration((builderContext, config) =>
        {
            if (args != null)
            {
                config.AddCommandLine(args);
            }
        })
        .UseIISIntegration()
        .UseStartup<StartUp>();
}
