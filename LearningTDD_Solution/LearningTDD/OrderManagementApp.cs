using Services.Interfaces.OrderHandling;
using System;

namespace LearningTDD
{
    public class OrderManagementApp
    {
        private readonly IOrder _order;

        // Inject Dependencies via Constructor.
        public OrderManagementApp(IOrder order)
        {
            _order = order;
        }

        /// <summary>
        /// This function is responsible to start the application
        /// when called from Program.cs file.
        /// </summary>
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application started successfully after setting up the DI Container.");

            HandleOrder();

            Console.Read();
        }

        private void HandleOrder()
        {
            try
            {
                _order.Handle();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Oops, an exception occurred while handling order. Details: {ex.Message}");
                throw;
            }
        }
    }
}
