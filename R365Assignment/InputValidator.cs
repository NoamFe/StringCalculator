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

        public decimal[] Validate(decimal[] input, bool allowNegative, decimal? maxNumberAllowed = null)
        {
            var invalidNumbers = new List<decimal>();
            var validNumbers = new List<decimal>();

            if (maxNumberAllowed == null)
                maxNumberAllowed = MaxNumberAllowed;

            foreach (var item in input)
            {
                if (!allowNegative)
                {
                    if (item < 0)
                    {
                        invalidNumbers.Add(item);
                    }
                }
                if (item <= maxNumberAllowed)
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
