﻿
namespace R365Assignment
{
    public class CalculatorClient : ICalculatorClient
    {
        readonly IInputParser _parser;
        readonly ICalculator _calculator;
        readonly IInputValidator _validator;
        readonly IOperatorProvider _operatorProvider;

        public CalculatorClient(ICalculator calculator, IInputParser parser,
            IInputValidator validator, IOperatorProvider operatorProvider)
        {
            _calculator = calculator ?? throw new System.ArgumentNullException(nameof(calculator));
            _parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
            _validator = validator ?? throw new System.ArgumentNullException(nameof(validator));
            _operatorProvider = operatorProvider ?? throw new System.ArgumentNullException(nameof(operatorProvider));
        }

        public string Calculate(string input, Operation operation)
        {
            var values = _parser.Parse(input);

            var validNumbers = _validator.Validate(values);

            var response = _calculator.Run(_operatorProvider.GetByOperation(operation),validNumbers);

            return response.ToString();
        }

    }
}
