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
        IOperatorProvider _operatorProvider;

        public CalculatorClientShould()
        {
            _calculator = A.Fake<ICalculator>();
            _inputParser = A.Fake<IInputParser>();
            _inputValidator = A.Fake<IInputValidator>();
            _operatorProvider = A.Fake<IOperatorProvider>();
            
            _calculatorClient = new CalculatorClient(_calculator, _inputParser, _inputValidator, _operatorProvider);
        }


        [Theory]
        [AutoFill]
        public void ThrowException_WhenValidatorThrowsException(string input, ArgumentException argumentException)
        {
            A.CallTo(() => _inputValidator.Validate(A<decimal[]>.Ignored , A<bool>.Ignored, A<decimal?>.Ignored)).Throws(argumentException);

            var calculatorInput = new CalculatorInput(input, Operation.Add);
            var exception = Should.Throw<ArgumentException>(() =>_calculatorClient.Calculate(calculatorInput));

            exception.ShouldBe(argumentException);            
        }

        [Theory]
        [AutoFill]
        public void CallCalculatorWithValidNumber_WhenValidatorReturnsValidNumbers(string input)
        {
            var numbers = new decimal[] { 1, 0, 5 };
            A.CallTo(() => _inputValidator.Validate(A<decimal[]>.Ignored, false, A<decimal?>.Ignored)).Returns(numbers);

            var calculatorInput = new CalculatorInput(input,Operation.Add);
            _calculatorClient.Calculate(calculatorInput);

            A.CallTo(() => _calculator.Run(A<Func<decimal, decimal, decimal>>.Ignored , numbers,
               A<string>.Ignored))
                .MustHaveHappenedOnceExactly();

            
        }

    }
}
