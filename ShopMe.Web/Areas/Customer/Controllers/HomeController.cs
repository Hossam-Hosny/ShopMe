using Microsoft.AspNetCore.Mvc;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;

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


        //public IActionResult Details(int id)
        //{

        //}


    }
}
