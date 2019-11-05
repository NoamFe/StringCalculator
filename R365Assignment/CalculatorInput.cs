using System;
using System.Collections.Generic;
using System.Text;

namespace R365Assignment
{
    public class CalculatorInput
    {
        public CalculatorInput(
            string input,
            Operation operation = Operation.Add,
            bool allowNegative = false,
            decimal? maxNumber = null,
            string? alternateDelimiter = null)
        {
            Input = input;
            Operation = operation;
            AllowNegative = allowNegative;
            AlternateDelimiter = alternateDelimiter;
            MaxNumber = maxNumber;
        }

        public Operation Operation { get; }
        public string Input { get; }
        public decimal? MaxNumber { get; }
        public bool AllowNegative { get; }
        public string? AlternateDelimiter { get; }
    }
}
