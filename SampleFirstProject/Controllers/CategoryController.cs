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

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category Obj)

        {
            if (Obj.Name == Obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "CategoryName cannot exactly match with Displayorder.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Sucessfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDB = _db.Categories.Find(id);
            /* Category? categoryfromDB1 = _db.Categories.FirstOrDefault(x => x.Id == id);
             Category? categoryfromDB2 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();*/
            if (categoryfromDB == null)
            {
                return NotFound();
            }
            return View(categoryfromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category Obj)

        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Sucessfully";
                return RedirectToAction("Index");
            }

            return View();
        }



        public IActionResult Delete(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryfromDB = _db.Categories.Find(id);
            /* Category? categoryfromDB1 = _db.Categories.FirstOrDefault(x => x.Id == id);
             Category? categoryfromDB2 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();*/
            if (categoryfromDB == null)
            {
                return NotFound();
            }
            return View(categoryfromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)

        {
            Category? obj= _db.Categories.Find(id);
            if (obj == null) { return NotFound(); }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Sucessfully";
            return RedirectToAction("Index");
            
        }

    }
}

