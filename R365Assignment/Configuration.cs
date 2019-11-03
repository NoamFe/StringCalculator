namespace R365Assignment
{
    public interface IConfiguration
    {
        int MaxSizeInput { get; }
        char[] Delimiters { get; }
    }

    public class Configuration : IConfiguration
    {
        public int MaxSizeInput => 2;
        public char[] Delimiters => new char[] { ',' };
    }
}
