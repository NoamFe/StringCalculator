using Microsoft.Extensions.DependencyInjection;
using System;

namespace R365Assignment
{  
    class Program
    {
        const string message = "Please input numbers using a comma delimiter or enter exit to exit";
        static void Main(string[] args)
        {
           
            ServiceProvider serviceProvider = ConfigureServices();

            var calculatorClient = serviceProvider.GetService<ICalculatorClient>();


            Console.WriteLine("Welcome to the amazing calculator\n ");
            Console.WriteLine(message);

            var input = Console.ReadLine();
            while (input != "exit")
            {
                try
                {
                    var response = calculatorClient.Calculate(input);
                    Console.WriteLine($"Total: {response}\n");                 
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(message);
                input = Console.ReadLine();
            }
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                            .AddScoped<IInputParser, InputParser>()
                            .AddScoped<ICalculator, Calculator>()
                            .AddScoped<ICalculatorClient, CalculatorClient>()
                            .AddScoped<IConfiguration, Configuration>()
                            .AddScoped<IInputValidator, InputValidator>()
                            .BuildServiceProvider();
        }
    }
}
