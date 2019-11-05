using System;
using System.Collections.Generic;
 
namespace R365Assignment
{
    public class OperatorProvider : IOperatorProvider
    {
        private Dictionary<Operation, Func<decimal, decimal, decimal>> _operations
            = new Dictionary<Operation, Func<decimal, decimal, decimal>>
        {
            {  Operation.Add, (a,b) => a+b },
            {  Operation.Subtract, (a,b) => a-b },
            {  Operation.Multiply, (a,b) => a*b },
            {  Operation.Divide, (a,b) => a/b },
        };


        private Dictionary<Operation, string> _symbols = new Dictionary<Operation, string>
        {
            {  Operation.Add,"+" },
            {  Operation.Subtract,"-" },
            {  Operation.Multiply, "*" },
            {  Operation.Divide, "/" }
        };

        public Func<decimal, decimal, decimal> GetByOperation(Operation operation)  => _operations[operation];

        public string GetSymbolByOperation(Operation operation) => _symbols[operation];
    }
}