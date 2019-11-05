using System.Collections.Generic;

namespace R365Assignment
{
    public interface ICustomDelimiterParser
    {
        List<string> Parse(ref string input);
    }
}