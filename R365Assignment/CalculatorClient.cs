
namespace R365Assignment
{
    public class CalculatorClient : ICalculatorClient
    {
        readonly IInputParser _parser;
        readonly ICalculator _calculator;
        public CalculatorClient(ICalculator calculator, IInputParser parser)
        {
            _calculator = calculator ?? throw new System.ArgumentNullException(nameof(calculator));
            _parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public string Calculate(string input)
        {
            var values = _parser.Parse(input);
            var response = _calculator.Add(values);

            return response.ToString(); ;
        }
    }
}
