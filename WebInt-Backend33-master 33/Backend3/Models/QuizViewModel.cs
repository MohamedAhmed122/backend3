using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Backend3.Models
{
    public class QuizViewModel
    {
        public Int32 ItemNumber { get; set; }
        public List<string> QuizQuestions { get; set; } = new List<string>();
        public List<int> QuizAnswer { get; set; } = new List<int>();
        public List<long> UserAnswer { get; set; } = new List<long>();
        public int CorrectAnswers { get; set; } = 0;
    }
}
