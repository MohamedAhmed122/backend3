using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend3.Services;
using Backend3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend3.Controllers
{
    public class QuizController : Controller
    {
        private readonly CalculationService calculationService;
        private readonly RandomizerService randomiserService;

        public QuizController(CalculationService CalculationService, RandomizerService randomiserService)
        {
            this.calculationService = CalculationService;
            this.randomiserService = randomiserService;
        }

        public IActionResult Index()
        {
            List<string> quizQuestions = new List<string>();
            List<int> quizResults = new List<int>();
            calculationService.Num1 = randomiserService.RanFunc();
            calculationService.Num2 = randomiserService.RanFunc();
            quizQuestions.Add(calculationService.RandomFunction(calculationService.Num1, calculationService.Num2));
            quizResults.Add(calculationService.RandomFunctionResult(calculationService.Num1, calculationService.Num2));

            var model = new QuizViewModel
            {
                QuizQuestions = quizQuestions,
                QuizAnswer = quizResults,
                ItemNumber = 0,
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Index(QuizViewModel model, QuizAction action)
        {
            long temp = 0;
            string answer = this.Request.Form["Answer"];
            if (!string.IsNullOrEmpty(answer))
            {
                temp = int.Parse(this.Request.Form["Answer"]);
            }
            switch (action)
            {
                case QuizAction.Submit:
                    model.ItemNumber++;
                    model.UserAnswer.Add(temp);
                    this.ModelState.Remove("ItemNumber");
                    calculationService.Num1 = randomiserService.RanFunc();
                    calculationService.Num2 = randomiserService.RanFunc();
                    model.QuizQuestions.Add(calculationService.RandomFunction(calculationService.Num1, calculationService.Num2));
                    model.QuizAnswer.Add(calculationService.RandomFunctionResult(calculationService.Num1, calculationService.Num2));
                    return this.View(model);
                case QuizAction.Finish:
                    for (int i = 0; i < model.QuizAnswer.Count-1; i++)
                    {
                        if (model.UserAnswer[i] == model.QuizAnswer[i])
                            model.CorrectAnswers += 1;
                    }
                    return this.View("Result", model);
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, null);
            }
        }
    }
}