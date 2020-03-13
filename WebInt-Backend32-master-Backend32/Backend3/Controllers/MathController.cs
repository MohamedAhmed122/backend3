using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend3.Models;
using Backend3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend3.Controllers
{
    public class MathController : Controller
    {
        private readonly INumberGeneratorService numbersService;
        private readonly ICalculatorService calculatorService;

        public MathController(INumberGeneratorService numbersService, ICalculatorService calculatorService)
        {
            this.numbersService = numbersService;
            this.calculatorService = calculatorService;
        }

        private char GetRandomArithmeticOperator() => "+-*/"[new Random().Next(4)];

        public IActionResult Index()
        {

            this.ViewBag.X = this.numbersService.GetNumber(1, 20);
            this.ViewBag.Op = GetRandomArithmeticOperator();
            this.ViewBag.Y = this.numbersService.GetNumber(1, 20);

            return View(new List<QuizViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(QuizAction action, List<QuizViewModel> model, QuizViewModel submitted)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            model.Add(submitted);

            if(action == QuizAction.Finish)
            {
                model.ForEach(entry =>
                {
                    switch (entry.Op)
                    {
                        case '+':
                            entry.Correct = (calculatorService.Add(entry.X, entry.Y) == entry.Answer);
                            break;
                        case '-':
                            entry.Correct = (calculatorService.Subtract(entry.X, entry.Y) == entry.Answer);
                            break;
                        case '/':
                            entry.Correct = (calculatorService.Divide(entry.X, entry.Y) == entry.Answer);
                            break;
                        case '*':
                            entry.Correct = (calculatorService.Multiply(entry.X, entry.Y) == entry.Answer);
                            break;
                    }
                });

                return this.View("Result", model);
            }

            this.ViewBag.X = this.numbersService.GetNumber(1, 20);
            this.ViewBag.Op = GetRandomArithmeticOperator();
            this.ViewBag.Y = this.numbersService.GetNumber(1, 20);

            this.ModelState.Remove("Answer");
            return this.View(model);
        }
    }
}