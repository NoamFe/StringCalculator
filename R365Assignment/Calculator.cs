using System;
using System.Linq;
using System.Text;

namespace R365Assignment
{
    public class Calculator : ICalculator
    { 
        public decimal Run(Func<decimal,decimal,decimal> calculatorOperation, decimal[] input, string operatorSymbol)
        { 
            if (input == null)
                return 0;

            var sb = new StringBuilder();
            sb.Append(input[0]);
            decimal accumulator = input[0];
            foreach (var n in input.Skip(1))
            {
                sb.Append($" {operatorSymbol} {n}");
                
                accumulator = calculatorOperation(accumulator, n);
            }

            Console.WriteLine(sb);
            return accumulator;
        }
         
    }
}
