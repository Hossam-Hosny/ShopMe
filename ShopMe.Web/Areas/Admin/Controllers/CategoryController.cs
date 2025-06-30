using Microsoft.AspNetCore.Mvc;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;
using ShopMe.Entities.Models;

namespace ShopMe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController(IUnitOfWork _unitOfWork) : Controller
{

    public IActionResult Index()
    {
        var categories = _unitOfWork.Category.GetAll();
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

            _unitOfWork.Category.Add(category);
            _unitOfWork.Complete();
            TempData["Create"] = "Data has been Created Successfully";


            return RedirectToAction("Index");
        }
        return View();
    }



    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var category = _unitOfWork.Category.GetFirstorDefault(c => c.Id == id);
        return View(category);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Category.Update(category);
            _unitOfWork.Complete();
            TempData["Update"] = "Data has been Updated Successfully";


            return RedirectToAction("Index");
        }



        return View(category);
    }


    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var category = _unitOfWork.Category.GetFirstorDefault(c => c.Id == id);
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCategory(int? id)
    {
        var category = _unitOfWork.Category.GetFirstorDefault(c => c.Id == id);
        if (category is null)
            return NotFound();
        _unitOfWork.Category.Remove(category);
        _unitOfWork.Complete();
        TempData["Delete"] = "Data has been Deleted Successfully";

        return RedirectToAction("Index");

    }
}
