using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;

namespace R365Assignment
{  
    class Program
    {
        const string message = "Please input numbers using a comma delimiter or enter exit to exit";
        const string typeOfOperationMessage = "Please select operation\n " +
            "press s for subtraction, m for multiplication, d for division or nothing for add";
        const string maxNumberMessage = "Please select max number to allow. default is 1000\n ";
        const string allowNegativeMessage = "Please select if you allow negative numbers press y. default is no\n ";
        const string alternateDelimitereMessage = "Please enter alternative delimiter. don't enter anything for default value \n ";


        static void Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eventArgs) => {
                Console.WriteLine("Ctrl+C pressed");
                Console.ReadLine();
                eventArgs.Cancel = true;};

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
                    Console.WriteLine(typeOfOperationMessage);
                    readlineValue = Console.ReadLine();
                    if (readlineValue == null)
                        return;

                    var operatorInput = Regex.Unescape(readlineValue);
                    var operation = GetOperator(operatorInput);

                    Console.WriteLine(maxNumberMessage);
                    readlineValue = Console.ReadLine();
                    if (readlineValue == null)
                        return;

                    decimal? maxNumberAllowed = GetMaxAllowed(readlineValue);



                    Console.WriteLine(allowNegativeMessage);
                    readlineValue = Console.ReadLine();
                    if (readlineValue == null)
                        return;
                    bool negativeAllowed = GetNegativeAllowed(readlineValue);


                    string? alternateDelimitere = null;
                    Console.WriteLine(alternateDelimitereMessage);
                    readlineValue = Console.ReadLine();
                    if (readlineValue == null)
                        return;
                    if(!string.IsNullOrWhiteSpace(readlineValue))
                        alternateDelimitere = readlineValue; 
                     
                    var calculatorInput = new CalculatorInput(input, operation, negativeAllowed, maxNumberAllowed, alternateDelimitere);
                    var response = calculatorClient.Calculate(calculatorInput);

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

        private static bool GetNegativeAllowed(string readlineValue)
        {
            bool allowed = false;
            if (string.IsNullOrWhiteSpace(readlineValue))
            {
                return allowed;
            }

            if (readlineValue == "y")
                return true;

            return allowed;
        }

        private static decimal? GetMaxAllowed(string readlineValue)
        {
            decimal? maxNumberAllowed = null;
            if (!string.IsNullOrWhiteSpace(readlineValue))
            {
                var canConvert = decimal.TryParse(readlineValue, out var number);
                if (canConvert)
                {
                    maxNumberAllowed = number;
                }
            }

            return maxNumberAllowed;
        }

        private static Operation GetOperator(string operatorInput)
        {
            if (operatorInput.Equals("s"))
                return Operation.Subtract;
            if (operatorInput.Equals("m"))
                return Operation.Multiply;
            if (operatorInput.Equals("d"))
                return Operation.Divide;
            return Operation.Add; 
        }

        private static ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                            .AddScoped<IOperatorProvider, OperatorProvider>()                
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
