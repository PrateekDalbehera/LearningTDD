using System;

namespace LearningTDD
{
    public class OrderManagementApp
    {
        // Inject Dependencies via Constructor.
        public OrderManagementApp()
        {

        }

        /// <summary>
        /// This function is responsible to start the application
        /// when called from Program.cs file.
        /// </summary>
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Application started successfully after setting up the DI Container.");
            Console.Read();
        }
    }
}
