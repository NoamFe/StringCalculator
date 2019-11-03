
namespace R365Assignment
{ 
    public class InputParser : IInputParser
    {
        private readonly char[] Delimiters;
       
        public InputParser(IConfiguration configuration)
        {
            Delimiters = configuration.Delimiters; 
        }

        public decimal[] Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new decimal[] { 0 };

            var values = input.Split(Delimiters); 

            decimal[] response = InitResponseObject(values.Length);

            int i = 0;
            foreach (var item in values)
            {
                var canConvert = decimal.TryParse(item, out var number);
                if (canConvert)
                {
                    response[i] = number;                   
                }
                i++;
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
