using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;

namespace R365Assignment
{  
    class Program
    {
        const string message = "Please input numbers using a comma delimiter or enter exit to exit";
        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eventArgs) => {
                Console.WriteLine("Ctrl+C pressed");
                Console.ReadLine();
                eventArgs.Cancel = true;
                 
            };

            ServiceProvider serviceProvider = ConfigureServices();

            var calculatorClient = serviceProvider.GetService<ICalculatorClient>();


            Console.WriteLine("Welcome to the amazing calculator\n ");
            Console.WriteLine(message);

            var readlineValue = Console.ReadLine();
            if (readlineValue == null)
                return;
            var input = Regex.Unescape(readlineValue);
          
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

                readlineValue = Console.ReadLine();
                if (readlineValue == null)
                    return;
                input = Regex.Unescape(readlineValue);
            }
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                            .AddScoped<ICustomDelimiterParser, CustomDelimiterParser>()
                            .AddScoped<IInputParser, InputParser>()
                            .AddScoped<ICalculator, Calculator>()
                            .AddScoped<ICalculatorClient, CalculatorClient>()
                            .AddScoped<IConfiguration, Configuration>()
                            .AddScoped<IInputValidator, InputValidator>()
                            .BuildServiceProvider();
        }
    }
}
