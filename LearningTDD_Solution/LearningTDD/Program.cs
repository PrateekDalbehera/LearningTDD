using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations.OrderHandling;
using Services.Interfaces.OrderHandling;
using Services.Interfaces.OrderHandling.MembershipMgmt;
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

                // [Not Required, check from Tests] Start the actual execution of the application.
                //serviceProvider.GetService<OrderManagementApp>().Run();

                Console.WriteLine($@"Nothing here, execute the Tests please...");
                Console.Read();
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

            services.AddTransient<IOrder, MembershipActivation>();
            services.AddTransient<IOrder, MembershipUpgradation>();

            services.AddTransient<IOrderType, MembershipOrderType>();
            services.AddTransient<IMembershipOrderType, MembershipOrderType>();

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
