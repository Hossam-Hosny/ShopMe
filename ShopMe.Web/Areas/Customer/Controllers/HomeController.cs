using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;
using ShopMe.Entities.Models;
using System.Security.Claims;

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


        public IActionResult Details(int ProductId)
        {
          
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                ProductId = ProductId,
                Product = _unitOfWork.Product.GetFirstorDefault(p => p.Id == ProductId, IncludeWord: "Category"),
                Count = 1
                
            };

            
            return View(shoppingCart);       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            shoppingCart.AppUserId = claim.Value;
            _unitOfWork.ShopingCart.Add(shoppingCart);
            _unitOfWork.Complete();

            return RedirectToAction("Index");


        }





    }
}
