using InfinityTeknoloji.Models.Models;
using InfinityTeknoloji.UI.Models;
using InfintyTeknoloji.Business.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InfinityTeknoloji.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuestionsManager _questionManager;
        private readonly AnswerManager _answerManager;
        public HomeController(ILogger<HomeController> logger,QuestionsManager questionsManager,AnswerManager answerManager)
        {
            _logger = logger;
            _questionManager = questionsManager;
            _answerManager = answerManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SolveExams(int ExamID)
        {
            var model = new SolveExamModel();
            var qs=_questionManager.Get(q => q.ExamID == ExamID);
            var questions = qs.Result.Data.ToList();
            model.Questions = questions;
            foreach (var item in questions)
            {
                var c=_answerManager.Get(q => q.QuestionID == item.QuestionID);
               
                  model.Answers=c.Result.Data.ToList();
                
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SolveExams()
        {
            return View();
        }
    }
}