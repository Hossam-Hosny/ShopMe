using Microsoft.AspNetCore.Mvc;
using ShopMe.Web.Context;
using ShopMe.Web.Models;

namespace ShopMe.Web.Controllers;

public class CategoryController(AppDbContext _db) : Controller
{

    public IActionResult Index()
    {
        var categories = _db.Categories.ToList();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {

            _db.Categories.Add(category);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        return View();
    }


}
