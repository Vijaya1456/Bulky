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

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category Obj)

        {
            if(Obj.Name==Obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("name","CategoryName cannot exactly match with Displayorder.");
            }
            if (ModelState.IsValid)
            { 
                _db.Categories.Add(Obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}
