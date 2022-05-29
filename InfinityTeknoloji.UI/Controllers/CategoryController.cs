using InfinityTeknoloji.Models.Models;
using InfintyTeknoloji.Business.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfinityTeknoloji.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger _logger;
        private readonly CategoryManager _categoryManager;
        public CategoryController(ILogger<CategoryController> logger, CategoryManager CategoryManager)
        {
            _logger = logger;
            _categoryManager = CategoryManager;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index()
        {
            var list = await _categoryManager.Get();
            if (list.IsSuccess)
                return View(list.Data);
            return View();
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int CategoryId)
        {
            var Category = await _categoryManager.GetById(CategoryId);
            if (Category.IsSuccess)
            {
                return View(Category.Data);
            }
            else
            {
                return View();
            }
        }

        // GET: CategoryController/Create
        public async Task<ActionResult> Create()
        {
            var CategoryDto = new CategoryDto();
            return View(CategoryDto);
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoryDto CategoryDto)
        {
            try
            {
                var result = await _categoryManager.Add(CategoryDto);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return View(CategoryDto);
            }
            catch
            {
                return View(CategoryDto);
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int CategoryId)
        {
            var Category = await _categoryManager.GetById(CategoryId);
            return View(Category.Data);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoryDto CategoryDto)
        {
            try
            {
                var Category = await _categoryManager.Update(CategoryDto);
                if (Category.IsSuccess)
                    return RedirectToAction(nameof(Index));
                else
                    return View(Category.Data);
            }
            catch
            {
                return View(CategoryDto);
            }
        }



        // POST: CategoryController/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {

                var result = await _categoryManager.Delete(id);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

    }
}
