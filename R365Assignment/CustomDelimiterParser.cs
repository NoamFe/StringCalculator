using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace R365Assignment
{
    public class CustomDelimiterParser : ICustomDelimiterParser
    {
        public List<string> Parse(ref string input)
        {
            var regexPattern = @"//(?<delimiter>(\D))\n(?<numbers>(.*))";
            var regex = new Regex(regexPattern, RegexOptions.ExplicitCapture);

            if (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                var numbers = match.Groups["numbers"].Value;
                var delimiter = match.Groups["delimiter"].Value;

                input = numbers;
                return new List<string> { delimiter };
            }

            return new List<string> {  };
        }
    }
}
