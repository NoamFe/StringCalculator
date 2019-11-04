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
        public void ThrowException_WhenValidatorThrowsException(string input, ArgumentException argumentException)
        {
            A.CallTo(() => _inputValidator.Validate(A<decimal[]>.Ignored)).Throws(argumentException);

            var exception = Should.Throw<ArgumentException>(() =>_calculatorClient.Calculate(input));

            exception.ShouldBe(argumentException);            
        }

        [Theory]
        [AutoFill]
        public void CallCalculatorWithValidNumber_WhenValidatorReturnsValidNumbers(string input)
        {
            var numbers = new decimal[] { 1, 0, 5 };
            A.CallTo(() => _inputValidator.Validate(A<decimal[]>.Ignored)).Returns(numbers);

            _calculatorClient.Calculate(input);

            A.CallTo(() => _calculator.Add(numbers)).MustHaveHappenedOnceExactly();

            
        }

    }
}
