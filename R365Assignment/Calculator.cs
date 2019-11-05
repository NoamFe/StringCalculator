using System;
using System.Linq; 

namespace R365Assignment
{
    public class Calculator : ICalculator
    { 
        public decimal Run(Func<decimal,decimal,decimal> calculatorOperation, decimal[] input)
        { 
            if (input == null)
                return 0;
          
            decimal accumulator = input[0];
            foreach (var n in input.Skip(1))
            {
                accumulator = calculatorOperation(accumulator, n);
            }
            return accumulator;
        }
         
    }
}
