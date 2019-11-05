
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace R365Assignment
{  
    public class InputParser : IInputParser
    {
        private List<string> Delimiters;
        private readonly ICustomDelimiterParser _customDelimiterParser;

        public InputParser(IConfiguration configuration, ICustomDelimiterParser customDelimiterParser)
        {
            Delimiters = new List<string> {};
            Delimiters.AddRange(configuration.Delimiters);

            _customDelimiterParser = customDelimiterParser;
        }

        public decimal[] Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new decimal[] { 0 };
            
            if (input.Length > 1 && input.Substring(0, 2).Equals(@"//"))
            { 
                var delimiters = _customDelimiterParser.Parse(ref input);
                Delimiters.AddRange(delimiters);               
            }
            var values = input.Split(Delimiters.ToArray(), System.StringSplitOptions.None);

            decimal[] response = InitResponseObject(values.Length);

            for (int i = 0; i < values.Length; i++)
            {
                var canConvert = decimal.TryParse(values[i], out var number);
                if (canConvert)
                {
                    response[i] = number;
                }
            } 

            return response;
        }

        private decimal[] InitResponseObject(int length)
        {
            var response = new decimal[length];
            for (int i = 0; i < length; i++)
            {
                response[i] = 0;
            }

            return response;
        }
    }
}
