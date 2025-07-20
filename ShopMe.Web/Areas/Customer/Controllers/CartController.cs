using Microsoft.AspNetCore.Mvc;
using ShopMe.Utilites.Constants;

namespace ShopMe.Web.Areas.Customer.Controllers
{
    [Area(nameof(UserArea.Customer))]
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
