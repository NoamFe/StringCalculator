using Xunit;
using Shouldly; 
using System.Text.RegularExpressions;

namespace R365Assignment.Tests
{
    public class CustomDelimiterParserShould
    {
        [Fact]
        public void ReturnDelimiterAndModityInput_RegexMatches()
        {
            var parser = new CustomDelimiterParser();
            var input = @"//#\n2#5,6,wrq#4";
            input = Regex.Unescape(input);

            var delimiters = parser.Parse(ref input);
            input.ShouldBe("2#5,6,wrq#4");
            delimiters.Count.ShouldBe(1);
            delimiters[0].ShouldBe("#");
        }
    }
}
