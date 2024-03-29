using Microsoft.AspNetCore.Mvc;
using SampleFirstProject.Data;
using SampleFirstProject.Models;

namespace SampleFirstProject.Controllers
{
    public class CategoryController : Controller

    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;       
        }
        public IActionResult Index()
        {
            List<Category> ObjCategoryList = _db.Categories.ToList();
            return View(ObjCategoryList);
        }
    }
}
