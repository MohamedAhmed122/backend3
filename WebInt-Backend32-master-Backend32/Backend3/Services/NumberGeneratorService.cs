using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Services
{
    public interface INumberGeneratorService
    {
        Int32 GetNumber(Int32 min, Int32 max);
    }

    public class NumberGeneratorService : INumberGeneratorService
    {

        private readonly Random random = new Random();

        public Int32 GetNumber(Int32 min, Int32 max)
        {
            return random.Next(min, max);
        }
    }
}
