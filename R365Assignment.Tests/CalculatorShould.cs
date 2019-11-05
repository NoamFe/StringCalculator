using Xunit;
using Shouldly;


namespace R365Assignment.Tests
{
    public class CalculatorShould
    {
        [Theory]
        [AutoFill]
        public void AddNumbersAndReturnResult_WhenCalled(decimal[] numbers)
        {
            var calculator = new Calculator();

            var operatorProvider = new OperatorProvider();
            var total = calculator.Run(operatorProvider.GetByOperation(Operation.Add), numbers);

            decimal expectedResults = 0;
            foreach (var item in numbers)
            {
                expectedResults += item;
            }

            total.ShouldBe(expectedResults);
        }


        [Theory]
        [AutoFill]
        public void DivideNumbersAndReturnResult_WhenCalled(decimal[] numbers)
        {
            var calculator = new Calculator();

            var operatorProvider = new OperatorProvider();
            var total = calculator.Run(operatorProvider.GetByOperation(Operation.Divide), numbers);

            decimal expectedResults = numbers[0] / numbers[1] / numbers[2];

            total.ShouldBe(expectedResults);
        }

        [Theory]
        [AutoFill]
        public void MultiplyNumbersAndReturnResult_WhenCalled(decimal[] numbers)
        {
            var calculator = new Calculator();

            var operatorProvider = new OperatorProvider();
            var total = calculator.Run(operatorProvider.GetByOperation(Operation.Multiply), numbers);

            decimal expectedResults = numbers[0] * numbers[1] * numbers[2];

            total.ShouldBe(expectedResults);
        }

        [Theory]
        [AutoFill]
        public void SubtractNumbersAndReturnResult_WhenCalled(decimal[] numbers)
        {
            var calculator = new Calculator();

            var operatorProvider = new OperatorProvider();
            var total = calculator.Run(operatorProvider.GetByOperation(Operation.Subtract), numbers);

            decimal expectedResults = numbers[0]- numbers[1]- numbers[2];
             
            total.ShouldBe(expectedResults);
        }

        [Fact] 
        public void AddNumbersAndReturnResult_WhenCalledWithNegativeNumbers()
        {
            var calculator = new Calculator();
            var operatorProvider = new OperatorProvider();
            var total = calculator.Run(operatorProvider.GetByOperation(Operation.Add),
                (new[] { (decimal)-1.1, (decimal)6, (decimal)-3, (decimal)2.4 }));
         
            total.ShouldBe((decimal)(-1.1+6-3+2.4));
        }

        [Fact]
        public void AddNumbersAndReturnResult_WhenCalledWithOutNumbers()
        {
            var calculator = new Calculator();

            var operatorProvider = new OperatorProvider();
            var total = calculator.Run(operatorProvider.GetByOperation(Operation.Add), null);
            
            total.ShouldBe(0);
        }
    }
}
