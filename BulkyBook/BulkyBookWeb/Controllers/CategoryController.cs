using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
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
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();

            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            
            return View();
        }
        //Post
        [HttpPost] //hook to make this a post route
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            //add custom validations (must be used with validation summary in view)
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid) //make sure that the inputs match the requirements of the model
            {
                _db.Categories.Add(obj); //add to database "post"
                _db.SaveChanges();//push changes to database
                return RedirectToAction("Index"); //redirect to "Index" page. use ("view":"controller") for dif controller
            }
            return View(obj);

        }

    }
}
