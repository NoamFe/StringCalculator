using System;

namespace R365Assignment
{
    public interface IOperatorProvider
    {
        Func<decimal, decimal, decimal> GetByOperation(Operation operation);
    }
}