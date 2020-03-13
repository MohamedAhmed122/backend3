using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend3.Models
{
    public enum QuizAction
    {
        Next,
        Finish
    }

    public class QuizViewModel
    {
        public int X { get; set; }
        public char Op { get; set; }
        public int Y { get; set; }
        public int? Answer { get; set; }

        public bool Correct { get; set; }

        public override String ToString()
        {
            return $"{X} {Op} {Y} = {Answer}";
        }
    }
}
