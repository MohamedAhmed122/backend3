using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Services
{
    public class RandomizerService
    {
        public int RanFunc()
        {
            Random r = new Random();
            int num = r.Next(1, 99999);
            return num;
        }
    }
}
