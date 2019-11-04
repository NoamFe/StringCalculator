using Xunit;
using Shouldly;
using FakeItEasy;
using System;

namespace R365Assignment.Tests
{
    public class CalculatorClientShould
    {
        ICalculatorClient _calculatorClient;
        ICalculator _calculator;
        IInputParser _inputParser;
        IInputValidator _inputValidator;

        public CalculatorClientShould()
        {
            _calculator = A.Fake<ICalculator>();
            _inputParser = A.Fake<IInputParser>();
            _inputValidator = A.Fake<IInputValidator>();

            _calculatorClient = new CalculatorClient(_calculator, _inputParser, _inputValidator);
        }


        [Theory]
        [AutoFill]
        public void ReturnTwoNumbers_WhenCallWith2Numbers(string input, ArgumentException argumentException)
        {
            A.CallTo(() => _inputValidator.Validate(A<decimal[]>.Ignored)).Throws(argumentException);

            var exception = Should.Throw<ArgumentException>(() =>_calculatorClient.Calculate(input));

            exception.ShouldBe(argumentException);
            
        }

    }
}
