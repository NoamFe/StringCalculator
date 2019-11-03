
namespace R365Assignment
{ 
    public class InputParser : IInputParser
    {
        private readonly char[] Delimiters;
        private readonly int MaxSize;

        public InputParser(IConfiguration configuration)
        {
            Delimiters = configuration.Delimiters;
            MaxSize = configuration.MaxSizeInput;
        }

        public decimal[] Parse(string input)
        {
            decimal[] response = InitResponseObject();
            if (string.IsNullOrEmpty(input))
                return response;

            var values = input.Split(Delimiters);

            var i = 0;
            foreach (var item in values)
            {
                var canConvert = decimal.TryParse(item, out var number);
                if (canConvert == true)
                {
                    response[i] = number;
                    i++;
                    if (i == MaxSize)
                        return response;
                }
            }
            return response;
        }

        private decimal[] InitResponseObject()
        {
            var response = new decimal[MaxSize];
            for (int i = 0; i < MaxSize; i++)
            {
                response[i] = 0;
            }

            return response;
        }
    }
}
