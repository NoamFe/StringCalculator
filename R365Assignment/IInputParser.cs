namespace R365Assignment
{
    public interface IInputParser
    {
        decimal[] Parse(string input, string alternativeDelimiter);
    }
}
