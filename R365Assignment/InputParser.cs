using System.Linq;
using System.Collections.Generic;

namespace R365Assignment
{  
    public class InputParser : IInputParser
    {
        private List<string> InitDelimiters;
        private readonly ICustomDelimiterParser _customDelimiterParser;

        public InputParser(IConfiguration configuration, ICustomDelimiterParser customDelimiterParser)
        {
            InitDelimiters = new List<string> {};
            InitDelimiters.AddRange(configuration.Delimiters);

            _customDelimiterParser = customDelimiterParser;
        }

        public decimal[] Parse(string input, string alternativeDelimiter)
        {
            if (string.IsNullOrEmpty(input))
                return new decimal[] { 0 };

            var delimiters = new List<string> { };

            if (alternativeDelimiter != null)
                delimiters.Add(alternativeDelimiter);
              
            if (input.Length > 1 && input.Substring(0, 2).Equals(@"//"))
            {                
                delimiters.AddRange(_customDelimiterParser.Parse(ref input, alternativeDelimiter));               
            }

            delimiters.AddRange(InitDelimiters);
           
            var values = input.Split(delimiters.ToArray(), System.StringSplitOptions.None).ToList();

            decimal[] response = InitResponseObject(values.Count);

            for (int i = 0; i < values.Count; i++)
            {
                var canConvert = decimal.TryParse(values[i], out var number);
                if (canConvert)
                {
                    response[i] = number;
                }
            }

            delimiters = new List<string> { };

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
