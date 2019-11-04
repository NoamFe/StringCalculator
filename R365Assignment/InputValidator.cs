using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace R365Assignment
{
    public class InputValidator : IInputValidator
    {
        readonly decimal MaxNumberAllowed;

        public InputValidator(IConfiguration configuration)
        {
            MaxNumberAllowed = configuration.MaxNumver;
        }

        public decimal[] Validate(decimal[] input)
        {
            var invalidNumbers = new List<decimal>();
            var validNumbers = new List<decimal>();

            foreach (var item in input)
            {
                if (item < 0)
                {
                    invalidNumbers.Add(item);
                }
                if (item <= MaxNumberAllowed)
                {
                    validNumbers.Add(item);
                }
                else
                {
                    validNumbers.Add(0);
                }
            }

            if (invalidNumbers.Any())
            {
                string number = string.Join(",", invalidNumbers.Select(n => string.Join(" ", n)));
                throw new ArgumentException($"negative numbers are not allowed: {number}");

            }
            return validNumbers.ToArray();
        }
    }
}
