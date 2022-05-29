using InfinityTeknoloji.Models.Models;
using InfintyTeknoloji.Business.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace InfinityTeknoloji.UI.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ILogger _logger;
        private readonly AnswerManager _answerManager;
        public AnswerController(ILogger<AnswerController> logger, AnswerManager AnswerManager)
        {
            _logger = logger;
            _answerManager = AnswerManager;
        }

        // GET: AnswerController
        public async Task<ActionResult> Index()
        {
            var list = await _answerManager.Get();
            if (list.IsSuccess)
                return View(list.Data);
            return View();
        }

        // GET: AnswerController/Details/5
        public async Task<ActionResult> Details(int AnswerId)
        {
            var Answer = await _answerManager.GetById(AnswerId);
            if (Answer.IsSuccess)
            {
                return View(Answer.Data);
            }
            else
            {
                return View();
            }
        }

        // GET: AnswerController/Create
        public async Task<ActionResult> Create(int QuestionID)
        {
            var AnswerDto = new AnswerDto();
            AnswerDto.QuestionID = QuestionID;
            return View(AnswerDto);
        }

        // POST: AnswerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AnswerDto AnswerDto)
        {
            try
            {
                var result = await _answerManager.Add(AnswerDto);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Create),"Answer",new {AnswerDto.QuestionID});
                else
                    return View(AnswerDto);
            }
            catch
            {
                return View(AnswerDto);
            }
        }

        // GET: AnswerController/Edit/5
        public async Task<ActionResult> Edit(int AnswerId)
        {
            var Answer = await _answerManager.GetById(AnswerId);
            return View(Answer.Data);
        }

        // POST: AnswerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AnswerDto AnswerDto)
        {
            try
            {
                var Answer = await _answerManager.Update(AnswerDto);
                if (Answer.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return View(Answer.Data);
            }
            catch
            {
                return View(AnswerDto);
            }
        }



        // POST: AnswerController/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {

                var result = await _answerManager.Delete(id);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
