using System;

namespace R365Assignment
{
    public interface ICalculator
    { 
        decimal Run(Func<decimal, decimal, decimal> calculatorOperation, decimal[] input);
    }
}