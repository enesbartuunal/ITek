using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfinityTeknoloji.Models.Models;
using InfintyTeknoloji.Business.Implementation;
using Microsoft.AspNetCore.Identity;
using InfinityTeknoloji.DataAccess.Entities;

namespace InfinityTeknoloji.UI.Controllers
{
    public class ExamController : Controller
    {
        private readonly ILogger _logger;
        private readonly ExamsManager _examsManager;
        private readonly CategoryManager _categoryManager;
        private readonly UserManager<User> _userManager;
        public ExamController(ILogger<ExamController> logger, ExamsManager examsManager,CategoryManager categoryManager,UserManager<User> userManager)
        {
            _logger = logger;
            _examsManager = examsManager;
            _categoryManager = categoryManager;
            _userManager = userManager;
        }

        // GET: ExamController
        public async Task<ActionResult> Index()
        {
            var list = await _examsManager.Get();
            if (list.IsSuccess)
                return View(list.Data);
            return View();
        }

        // GET: ExamController/Details/5
        public async Task<ActionResult> Details(int ExamId)
        {
            var exam = await _examsManager.GetById(ExamId);
            if (exam.IsSuccess)
            {
                return View(exam.Data);
            }
            else
            {
                return View();
            }
        }

        // GET: ExamController/Create
        public async Task<ActionResult> Create()
        {
            var examDto = new ExamDto();
            var categoryList = _categoryManager.Get();
            ViewData["CategoryList"] = categoryList.Result.Data;
            return View(examDto);
        }

        // POST: ExamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ExamDto examDto)
        {
            try
            {
                var result = await _examsManager.Add(examDto);
                if (result.IsSuccess)
                    
                    return RedirectToAction(nameof(Create), "Question", new {result.Data.ExamID});
                else
                    return View(examDto);
            }
            catch
            {
                return View(examDto);
            }
        }

        // GET: ExamController/Edit/5
        public async Task<ActionResult> Edit(int ExamId)
        {
            var exam = await _examsManager.GetById(ExamId);
            return View(exam.Data);
        }

        // POST: ExamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ExamDto examDto)
        {
            try
            {
                var exam = await _examsManager.Update(examDto);
                if (exam.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return View(exam.Data);
            }
            catch
            {
                return View(examDto);
            }
        }



        // POST: ExamController/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
              
                var result = await _examsManager.Delete(id);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

     
        //public async Task<IActionResult> AssignmentUser(int ExamID)
        //{
        //    try
        //    {
        //        var userList = _userManager.Users.ToList();
                
        //        ViewData["UserList"] = userList;
        //        return View(ExamID);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //[HttpPost]
        //public async Task<IActionResult> AssignmentUser(List<User> users,int ExamID)
        //{
        //    try
        //    {
        //        var exam = _examsManager.GetById(ExamID);
        //        foreach (var item in users)
        //        {
        //            exam.Result.Data.Users.Add();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
