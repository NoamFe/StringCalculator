using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace R365Assignment
{
    public class CustomDelimiterParser : ICustomDelimiterParser
    {
        public List<string> Parse(ref string input)
        {
            var newline = "\n";          
            var regexPattern = $"//((?<delimiter>(\\D))|\\[(?<delimiter>[^\\]]*)\\]|(\\[(?<delimiter>[^\\]])*\\])+){newline}(?<numbers>(.*))";

            var regex = new Regex(regexPattern, RegexOptions.ExplicitCapture);

            if (regex.IsMatch(input))
            {
                var match = regex.Match(input);
                input = match.Groups["numbers"].Value;
                
                var delimiters =  match.Groups["delimiter"].Captures.Select(m => m.Value).ToList();
                
                return delimiters;
            }

            return new List<string> {  };
        }
    }
}
