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



    [HttpGet]
    public IActionResult Edit (int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var category = _db.Categories.Find(id);
        return View(category);
    }
      [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit (Category category)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
            

       
        return View(category);
    }



}
