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

            var delimiters = parser.Parse(ref input,string.Empty);
            input.ShouldBe("2#5,6,wrq#4");
            delimiters.Count.ShouldBe(1);
            delimiters[0].ShouldBe("#");
        }

        [Fact]
        public void ReturnDelimiterAndModifyInput_WhenRegexMatchesAndCalledWithAlternativeDelimiter()
        {
            var parser = new CustomDelimiterParser();
            var input = @"//#\a2#5,6,wrq#4";
            input = Regex.Unescape(input);

            var delimiters = parser.Parse(ref input, @"\a");
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

            var delimiters = parser.Parse(ref input, string.Empty);
            input.ShouldBe("11***22***33,7***10");
            delimiters.Count.ShouldBe(1);
            delimiters[0].ShouldBe("***");
        }


        [Fact]
        public void ReturnDelimitersAndModifyInput_WhenCalledWithMultiDelimiterAndRegexMatches()
        {
            var parser = new CustomDelimiterParser();
            var input = @"//[*][!!][r9r]\n11r9r22*hh*33!!44";
            input = Regex.Unescape(input);

            var delimiters = parser.Parse(ref input, string.Empty);
            input.ShouldBe("11r9r22*hh*33!!44");
            delimiters.Count.ShouldBe(3);
            delimiters[0].ShouldBe("*");
            delimiters[1].ShouldBe("!!");
            delimiters[2].ShouldBe("r9r");
        }

    }
}
