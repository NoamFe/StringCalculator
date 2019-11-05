namespace R365Assignment
{
    public interface IInputValidator
    {
        decimal[] Validate(decimal[] input, bool allowNegative, decimal? maxNumberAllowed = null);
    }
}