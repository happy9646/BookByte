using BookByte.DataAccess.Repository.IRepository;
using BookByte.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookByte.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
      private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
                _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region APIs
        public IActionResult GetAll()
        {
            var categoryList = _unitOfWork.Category.GetAll();
            return Json(new { data = categoryList });

        }
        #endregion 
        // here Upsert works for both Create and Update
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            //Create 
            if (id == null) return View(category);
            //Edit
            category = _unitOfWork.Category.Get(id.GetValueOrDefault());
            if (category == null) return NotFound();
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (category == null) return NotFound();
            if (!ModelState.IsValid) return View(category);
            if (category.Id == 0)
                _unitOfWork.Category.Add(category);
            else
                _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
