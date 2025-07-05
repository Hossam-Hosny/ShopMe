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
        var products = _unitOfWork.Product.GetAll(IncludeWord:"Category");
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
                var upload = Path.Combine(rootPath, @"Images\Products\");
                var extension = Path.GetExtension(file.FileName);

                using (var filestream = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                productvm.Product.ImagePath = $"Images/Products/{ filename}{extension}";

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

        var productVM = new ProductViewModel()
        {
            Product = _unitOfWork.Product.GetFirstorDefault(c => c.Id == id),
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
    public IActionResult Edit(ProductViewModel productvm,IFormFile? file)
    {
        if (ModelState.IsValid)
        {

            string rootPath = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString();
                var upload = Path.Combine(rootPath, @"Images\Products");
                var extension = Path.GetExtension(file.FileName);

                if (productvm.Product.ImagePath != null)
                {
                    var oldImagePath = Path.Combine(rootPath, productvm.Product.ImagePath.Replace("/", Path.DirectorySeparatorChar.ToString()).Replace("\\", Path.DirectorySeparatorChar.ToString()));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                    
                }


                using (var filestream = new FileStream(Path.Combine(upload, filename + extension), FileMode.Create))
                {
                    file.CopyTo(filestream);
                }

                productvm.Product.ImagePath = $"Images/Products/{filename}{extension}";

            }




            _unitOfWork.Product.Update(productvm.Product);
            _unitOfWork.Complete();
            TempData["Update"] = "Data has been Updated Successfully";


            return RedirectToAction("Index");
        }



        return View(productvm.Product);
    }



    
    public IActionResult Delete(int? id)
    {
        var product = _unitOfWork.Product.GetFirstorDefault(c => c.Id == id);
        if (product is null)
          return Json(new {success = false, message="Some Thing went wrong"});


        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,product!.ImagePath.Replace("/", Path.DirectorySeparatorChar.ToString()).Replace("\\", Path.DirectorySeparatorChar.ToString()));
        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }


        _unitOfWork.Product.Remove(product);
        _unitOfWork.Complete();

        return Json(new {success = true, message="Product Has Been Deleted"});


    }
}
