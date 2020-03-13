using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Services
{
    public interface ICalculatorService
    {
        Int32 Add(Int32 x, Int32 y);
        Int32 Subtract(Int32 x, Int32 y);
        Int32 Multiply(Int32 x, Int32 y);
        Int32 Divide(Int32 x, Int32 y);
    }

    public class CalculatorService : ICalculatorService
    {
        public Int32 Add(Int32 x, Int32 y)
        {
            return x + y;
        }

        public Int32 Divide(Int32 x, Int32 y)
        {
            return x / y;
        }

        public Int32 Multiply(Int32 x, Int32 y)
        {
            return x * y;
        }

        public Int32 Subtract(Int32 x, Int32 y)
        {
            return x - y;
        }
    }
}
