using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LearningTDD
{
    class Program
    {
        private static string _CONFIG_FILE = "appsettings.json";

        static void Main(string[] args)
        {
			try
			{
                Console.WriteLine("Starting Order Management System...");

                var services = ConfigureServices();

                // Create Provider to use Dependency Injector
                var serviceProvider = services.BuildServiceProvider();

                // Start the actual execution of the application.
                serviceProvider.GetService<OrderManagementApp>().Run();
            }
			catch (Exception ex)
			{
                Console.WriteLine($@"Something went wrong, an error occurred.
                        Error Message: {ex.Message}
                        StackTrace: {ex.StackTrace}");
                Console.Read();
			}
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            // Set up the objects we need to get to configuration settings
            var config = LoadConfiguration();

            services.AddSingleton(config);

            // IMPORTANT: Register the application entry point.
            services.AddTransient<OrderManagementApp>();

            return services;
        }

        private static IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(_CONFIG_FILE, optional: true, reloadOnChange: true)

                    .Build();
        }
    }
}
