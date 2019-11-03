
namespace R365Assignment
{
    public class Calculator : ICalculator
    {
        public decimal Add(decimal[] input)
        {
            decimal total = 0;
            if (input == null)
                return total;

            foreach (var item in input)
            {
                total += item;
            }

            return total;
        }
    }
}
