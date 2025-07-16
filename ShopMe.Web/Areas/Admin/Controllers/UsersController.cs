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

    public IActionResult LockUnlock(string? Id)
    {
        var user = _db.appUsers.FirstOrDefault(x => x.Id == Id);
        if (user is null)
            return NotFound();

        if (user.LockoutEnd == null || user.LockoutEnd < DateTime.Now)
            user.LockoutEnd = DateTime.Now.AddYears(1);

        else
        {
            user.LockoutEnd = DateTime.Now;
        }
        _db.SaveChanges();
        return RedirectToAction("Index","Users",new {area = "Admin"});
    }

}
