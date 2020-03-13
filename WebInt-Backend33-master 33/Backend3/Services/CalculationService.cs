using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend3.Services
{
    public class CalculationService
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Result { get; set; }
        int decider;

        public int Addition => Num1;

        public int AdditionFunc(int num1, int num2)
        {
            int result = num1 + num2;
            return result;
        }
        public int SubstractionFunc(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
        public int DivisionFunc(int num1, int num2)
        {
            int result = num1 / num2;
            return result;
        }
        public int MultiplicationFunc(int num1, int num2)
        {
            int result = num1 * num2;
            return result;
        }
        public string RandomFunction (int num1, int num2)
        {
            Random r = new Random();
            decider = r.Next(0, 4);
            if (decider == 0) return Num1 + " + " + num2 + " = ";
            else if (decider == 1) return num1 + " - " + num2 + " = ";
            else if (decider == 2) return num1 + " / " + num2 + " = ";
            else if (decider == 3) return num1 + " * " + num2 + " = ";
            return "";
        }
        public int RandomFunctionResult(int num1, int num2)
        {
            if (decider == 0) return AdditionFunc(num1, num2);
            else if (decider == 1) return SubstractionFunc(num1, num2);
            else if (decider == 2) return DivisionFunc(num1, num2);
            else if (decider == 3) return MultiplicationFunc(num1, num2);
            return 0;
        }
    }
}
