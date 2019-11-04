
namespace R365Assignment
{
    public class CalculatorClient : ICalculatorClient
    {
        readonly IInputParser _parser;
        readonly ICalculator _calculator;
        readonly IInputValidator _validator;

        public CalculatorClient(ICalculator calculator, IInputParser parser, IInputValidator validator)
        {
            _calculator = calculator ?? throw new System.ArgumentNullException(nameof(calculator));
            _parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
            _validator = validator ?? throw new System.ArgumentNullException(nameof(validator));
        }

        public string Calculate(string input)
        {
            var values = _parser.Parse(input);

            _validator.Validate(values);

            var response = _calculator.Add(values);

            return response.ToString();
        }
    }
}
