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

        #region APIs
        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryInDb = _unitOfWork.Category.Get(id);
            if (categoryInDb == null)
                return Json(new { success = false, message = "Something went wrong while deleting !!!" });
            _unitOfWork.Category.Remove(categoryInDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = " data deleted successfully !!!" });
        }
        #endregion
        #region APIs
        [HttpGet]                             
        public IActionResult GetAll()
        {
            var categoryList = _unitOfWork.Category.GetAll();
            return Json(new { data = categoryList });
        }
        #endregion 

        [HttpGet]                             

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