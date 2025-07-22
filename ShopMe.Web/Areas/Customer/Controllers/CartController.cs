using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;
using ShopMe.Entities.Models.ViewModels;
using ShopMe.Utilites.Constants;
using System.Security.Claims;

namespace ShopMe.Web.Areas.Customer.Controllers
{
    [Area(nameof(UserArea.Customer))]
    [Authorize]
    public class CartController(IUnitOfWork _unitOfWork) : Controller
    {
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public IActionResult Index()
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                CartsList = _unitOfWork.ShopingCart.GetAll(u => u.AppUserId == claim.Value,IncludeWord:"Product")
            };

            foreach(var item in ShoppingCartVM.CartsList)
            {
                ShoppingCartVM.TotalCarts += (item.Count * item.Product.Price);
            }

            return View(ShoppingCartVM);

        }

        public IActionResult Plus(int cartid)
        {
            var shoppingcart = _unitOfWork.ShopingCart.GetFirstorDefault(x => x.Id == cartid);
            _unitOfWork.ShopingCart.IncreaseCount(shoppingcart, 1);
            _unitOfWork.Complete();

            return RedirectToAction("Index");

        }

        public IActionResult Minus(int cartid)
        {
            var shoppingcart = _unitOfWork.ShopingCart.GetFirstorDefault(x => x.Id == cartid);
           
            if (shoppingcart.Count <= 1)
            {
                _unitOfWork.ShopingCart.Remove(shoppingcart);
                _unitOfWork.Complete();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _unitOfWork.ShopingCart.DencreaseCount(shoppingcart, 1);

            }
            _unitOfWork.Complete();

            return RedirectToAction("Index");

        }


        public IActionResult Remove(int cartid)
        {
            var shoppingcart = _unitOfWork.ShopingCart.GetFirstorDefault(x => x.Id == cartid);
            _unitOfWork.ShopingCart.Remove(shoppingcart);
            _unitOfWork.Complete();

            return RedirectToAction("Index");

        }
    }
}
