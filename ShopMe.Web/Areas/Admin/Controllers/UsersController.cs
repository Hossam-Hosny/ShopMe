using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopMe.DataAccess.Context;
using ShopMe.Utilites.Constants;
using System.Security.Claims;

namespace ShopMe.Web.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles ="Admin")]
public class UsersController(AppDbContext _db) : Controller
{
    public IActionResult Index()
    {
        var claimsIdentity =(ClaimsIdentity) User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        string userId = claim.Value;



        return View(_db.appUsers.Where(x=>x.Id != userId).ToList());
    }
}
