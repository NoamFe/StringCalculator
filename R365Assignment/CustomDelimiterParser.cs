using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
                var delimiters = new List<string>();

                if (input.StartsWith("//["))
                {
                    var indexOfNewLine = input.IndexOf('\n');
                    char[] internalDelimiters = { '[',']'};  
                    foreach (var splitInput in input.Substring(3, indexOfNewLine - 3).Split(internalDelimiters))
                    {
                        if (splitInput.Length > 0)
                            delimiters.Add(splitInput);
                    }
                    input = input.Substring(indexOfNewLine + 1);
                }
                else 
                {
                    delimiters = match.Groups["delimiter"].Captures.Select(m => m.Value).ToList();

                    input = match.Groups["numbers"].Value;
                }                

                return delimiters;
            }

            return new List<string> {  };
        }
    }
}
