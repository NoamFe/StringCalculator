
namespace R365Assignment
{ 
    public class InputParser : IInputParser
    {
        private readonly string[] Delimiters;
       
        public InputParser(IConfiguration configuration)
        {
            Delimiters = configuration.Delimiters; 
        }

        public decimal[] Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new decimal[] { 0 };
             
            var values = input.Split(Delimiters, System.StringSplitOptions.None);

            decimal[] response = InitResponseObject(values.Length);

            for (int i = 0; i < values.Length; i++)
            {
                var canConvert = decimal.TryParse(values[i], out var number);
                if (canConvert)
                {
                    response[i] = number;
                }
            } 

            return response;
        }

        private decimal[] InitResponseObject(int length)
        {
            var response = new decimal[length];
            for (int i = 0; i < length; i++)
            {
                response[i] = 0;
            }

            return response;
        }
    }
}
