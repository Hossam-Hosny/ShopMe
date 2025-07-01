using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;
using ShopMe.Entities.Models;
using ShopMe.Entities.Models.ViewModels;

namespace ShopMe.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class ProductController(IUnitOfWork _unitOfWork 
    ,IWebHostEnvironment _webHostEnvironment
    ): Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetData()
    {
        var products = _unitOfWork.Product.GetAll();
        return Json(new {data=products});
    }

    [HttpGet]
    public IActionResult Create()
    {
        var productVM = new ProductViewModel()
        {
            Product = new Product(),
            CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()

            })
        };
        return View(productVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm]ProductViewModel productvm,IFormFile file)
    {
        if (ModelState.IsValid)
        {
            string rootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var upload = Path.Combine(rootPath, @"Images\Products");
                var extension = Path.GetExtension(file.FileName);

                using (var filestream = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                productvm.Product.ImagePath = @"Images\Products" + filename + extension;

            }

            _unitOfWork.Product.Add(productvm.Product);
            _unitOfWork.Complete();
            TempData["Create"] = "Data has been Created Successfully";


            return RedirectToAction("Index");
        }
        return View(productvm);
    }



    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var product = _unitOfWork.Product.GetFirstorDefault(c => c.Id == id);
        return View(product);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Update(product);
            _unitOfWork.Complete();
            TempData["Update"] = "Data has been Updated Successfully";


            return RedirectToAction("Index");
        }



        return View(product);
    }


    [HttpGet]
    public IActionResult Delete(int? id)
    {
        if (id is null || id == 0)
            return NotFound();

        var product = _unitOfWork.Product.GetFirstorDefault(c => c.Id == id);
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteProduct(int? id)
    {
        var product = _unitOfWork.Product.GetFirstorDefault(c => c.Id == id);
        if (product is null)
            return NotFound();
        _unitOfWork.Product.Remove(product);
        _unitOfWork.Complete();
        TempData["Delete"] = "Data has been Deleted Successfully";

        return RedirectToAction("Index");

    }
}
