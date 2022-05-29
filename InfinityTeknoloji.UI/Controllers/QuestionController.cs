using InfinityTeknoloji.Models.Models;
using InfintyTeknoloji.Business.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfinityTeknoloji.UI.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ILogger _logger;
        private readonly QuestionsManager _questionsManager;
        public QuestionController(ILogger<QuestionController> logger, QuestionsManager QuestionsManager)
        {
            _logger = logger;
            _questionsManager = QuestionsManager;
        }

        // GET: QuestionController
        public async Task<ActionResult> Index()
        {
            var list = await _questionsManager.Get();
            if (list.IsSuccess)
                return View(list.Data);
            return View();
        }

        // GET: QuestionController/Details/5
        public async Task<ActionResult> Details(int QuestionId)
        {
            var Question = await _questionsManager.GetById(QuestionId);
            if (Question.IsSuccess)
            {
                return View(Question.Data);
            }
            else
            {
                return View();
            }
        }

        // GET: QuestionController/Create
        public async Task<ActionResult> Create(int ExamID)
        {
            var QuestionDto = new QuestionDto();
            QuestionDto.ExamID = ExamID;
            return View(QuestionDto);
        }

        // POST: QuestionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionDto QuestionDto)
        {
            try
            {
                var result = await _questionsManager.Add(QuestionDto);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Create), "Answer",new {result.Data.QuestionID });
                else
                    return View(QuestionDto);
            }
            catch
            {
                return View(QuestionDto);
            }
        }

        // GET: QuestionController/Edit/5
        public async Task<ActionResult> Edit(int QuestionId)
        {
            var Question = await _questionsManager.GetById(QuestionId);
            return View(Question.Data);
        }

        // POST: QuestionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuestionDto QuestionDto)
        {
            try
            {
                var Question = await _questionsManager.Update(QuestionDto);
                if (Question.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return View(Question.Data);
            }
            catch
            {
                return View(QuestionDto);
            }
        }



        // POST: QuestionController/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {

                var result = await _questionsManager.Delete(id);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}