using BookByte.DataAccess.Repository.IRepository;
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
    }
}
