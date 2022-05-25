using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfinityTeknoloji.Models.Models;
using InfintyTeknoloji.Business.Implementation;

namespace InfinityTeknoloji.UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger _logger;
        private readonly ExamsManager  _examsManager;
        public ExamController(ILogger logger,ExamsManager examsManager)
        {
            _logger = logger;
            _examsManager = examsManager;
        }

        // GET: ExamController
        public ActionResult Index()
        {
            var list=_examsManager.Get();
            if(list.Result.IsSuccess)
            return View(list);
            return View();
        }

        // GET: ExamController/Details/5
        public ActionResult Details(int id)
        {
            var exam = _examsManager.GetById(id);
            if (exam.IsCompletedSuccessfully)
            {
                return View(exam);
            }
            else
            {
                return View();
            }
        }

        // GET: ExamController/Create
        public ActionResult Create()
        {
            var examDto = new ExamDto();
            return View(examDto);
        }

        // POST: ExamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExamDto examDto)
        {
            try
            {
                var result=_examsManager.Add(examDto);
                if (result.IsCompleted)
                    return RedirectToAction(nameof(Index));
                else
                    return View(examDto);
            }
            catch
            {
                return View(examDto);
            }
        }

        // GET: ExamController/Edit/5
        public ActionResult Edit(int id)
        {
            var exam=_examsManager.GetById(id);
            return View(exam);
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExamDto examDto)
        {
            try
            {
                var exam=_examsManager.Update(examDto);
                if (exam.IsCompletedSuccessfully)
                    return RedirectToAction(nameof(Index));
                else
                    return View(exam);
            }
            catch
            {
                return View(examDto);
            }
        }

        // GET: ExamController/Delete/5
        public ActionResult Delete(int id)
        {
            var exam = _examsManager.GetById(id);
            return View(exam);
        }

        // POST: ExamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,ExamDto examDto)
        {
            try
            {
                var result=_examsManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
