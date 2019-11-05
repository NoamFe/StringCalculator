using Xunit;
using Shouldly; 
using System.Text.RegularExpressions;

namespace R365Assignment.Tests
{
    public class CustomDelimiterParserShould
    {
        [Fact]
        public void ReturnDelimiterAndModifyInput_WhenRegexMatches()
        {
            var parser = new CustomDelimiterParser();
            var input = @"//#\n2#5,6,wrq#4";
            input = Regex.Unescape(input);

            var delimiters = parser.Parse(ref input);
            input.ShouldBe("2#5,6,wrq#4");
            delimiters.Count.ShouldBe(1);
            delimiters[0].ShouldBe("#");
        }

        [Fact]
        public void ReturnDelimiterAndModifyInput_WhenCalledWithLongDelimiterAndRegexMatches()
        {
            var parser = new CustomDelimiterParser();
            var input = @"//[***]\n11***22***33,7***10";
            input = Regex.Unescape(input);

            var delimiters = parser.Parse(ref input);
            input.ShouldBe("11***22***33,7***10");
            delimiters.Count.ShouldBe(1);
            delimiters[0].ShouldBe("***");
        }
        
    }
}
