using Xunit;
using Shouldly; 
using FakeItEasy;

namespace R365Assignment.Tests
{
    public class InputParserShould
    {
        IInputParser parser;
        public InputParserShould()
        {
            var configuration = A.Fake<IConfiguration>();
            A.CallTo(() => configuration.MaxSizeInput).Returns(2);

            A.CallTo(() => configuration.Delimiters).Returns(new char[] { ',' });

            parser = new InputParser(configuration);
        }
        [Theory]
        [AutoFill]
        public void ReturnTwoNumbers_WhenCallWith2Numbers(decimal number1, decimal number2)
        {
            var numbers = parser.Parse($"{number1},{number2}");
            numbers.Length.ShouldBe(2);
            numbers[0].ShouldBe<decimal>(number1);
            numbers[1].ShouldBe(number2);
        }

        [Theory]
        [AutoFill]
        public void ReturnTwoNumbers_WhenCallWith3Numbers(decimal number1, decimal number2, decimal number3)
        { 
            var numbers = parser.Parse($"{number1},{number2},{number3}");
            numbers.Length.ShouldBe(2);
            numbers[0].ShouldBe<decimal>(number1);
            numbers[1].ShouldBe(number2);
        }

        [Theory]
        [AutoFill]
        public void ReturnTwoNumbers_WhenCallWith2InvalidChars(string invalidString1 ,string invalidString2)
        { 
            var numbers = parser.Parse($"{invalidString1},{invalidString2}");
            numbers.Length.ShouldBe(2);
            numbers[0].ShouldBe(0);
            numbers[1].ShouldBe(0);
        }

        [Theory]
        [AutoFill]
        public void ReturnTwoNumbers_WhenCallWith1NumberAndInvalidChars(decimal number1)
        { 
            var numbers = parser.Parse($"{number1},aa");
            numbers.Length.ShouldBe(2);
            numbers[0].ShouldBe<decimal>(number1);
            numbers[1].ShouldBe(0);
        }

        [Theory]
        [AutoFill]
        public void ReturnZeroTwoNumbers_WhenCallWithEmptyString()
        { 

            var numbers = parser.Parse(null);
            numbers.Length.ShouldBe(2);
            numbers[0].ShouldBe(0);
            numbers[1].ShouldBe(0);
        }
    }
}
