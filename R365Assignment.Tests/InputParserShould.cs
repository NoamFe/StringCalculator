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
             
            A.CallTo(() => configuration.Delimiters).Returns(new string[] { ",", @"\n" });

            parser = new InputParser(configuration);
        }
        [Theory]
        [AutoFill]
        public void ReturnTwoNumbers_WhenCallWith2Numbers(decimal number1, decimal number2)
        {
            var numbers = parser.Parse($"{number1},{number2}");
            numbers.Length.ShouldBe(2);
            numbers[0].ShouldBe(number1);
            numbers[1].ShouldBe(number2);
        }

        [Theory]
        [AutoFill]
        public void ReturnAllNumbers_WhenCallWithFewNumbers(decimal number1, decimal number2, decimal number3)
        { 
            var numbers = parser.Parse($"{number1},aaa,{number2},{number3}");
            numbers.Length.ShouldBe(4);
            numbers[0].ShouldBe(number1);
            numbers[1].ShouldBe(0);
            numbers[2].ShouldBe(number2);
            numbers[3].ShouldBe(number3);
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
            numbers[0].ShouldBe(number1);
            numbers[1].ShouldBe(0);
        }

        [Theory]
        [AutoFill]
        public void ReturnZeroTwoNumbers_WhenCallWithEmptyString()
        { 

            var numbers = parser.Parse(null);
            numbers.Length.ShouldBe(1);
            numbers[0].ShouldBe(0); 
        }

        [Theory]
        [AutoFill]
        public void ReturnAllNumbers_WhenCallWithMultipleDelimeters(decimal number1, decimal number2, decimal number3)
        {
            var numbers = parser.Parse($@"{number1},aa,{number2}\n{number3}");
            numbers.Length.ShouldBe(4);
            numbers[0].ShouldBe(number1);
            numbers[1].ShouldBe(0);
            numbers[2].ShouldBe(number2);
            numbers[3].ShouldBe(number3);
        }

    }
}
