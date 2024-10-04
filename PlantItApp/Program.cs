using Microsoft.AspNetCore.Hosting;

namespace PlantItApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a default host builder with environment-specific configuration
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    var env = context.HostingEnvironment;

                    // Add configuration files based on environment
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                          .AddUserSecrets<Program>() // For development-time secrets
                          .AddEnvironmentVariables(); // To support environment variables
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("https://localhost:5001");
                });
    }
}
