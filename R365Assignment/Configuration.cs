namespace R365Assignment
{
    public interface IConfiguration
    {
        char[] Delimiters { get; }
    }

    public class Configuration : IConfiguration
    {
        public char[] Delimiters => new char[] { ',' };
    }
}
