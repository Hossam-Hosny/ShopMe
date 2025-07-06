using Microsoft.AspNetCore.Mvc;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;
using ShopMe.Entities.Models.ViewModels;

namespace ShopMe.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController(IUnitOfWork _unitOfWork) : Controller
    {
        public IActionResult Index()
        {

            var product = _unitOfWork.Product.GetAll();

            return View(product);
        }


        public IActionResult Details(int id)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.GetFirstorDefault(p => p.Id == id, IncludeWord: "Category"),
                Count = 1
                
            };
            


            return View(shoppingCart);       
        }


    }
}
