namespace R365Assignment
{
    public class Configuration : IConfiguration
    {
        public string[] Delimiters => new string[] { ",", @"\n" };
        public decimal MaxNumver => 1000;
    }
}
 
