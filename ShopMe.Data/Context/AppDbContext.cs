using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopMe.Entities.Models;

namespace ShopMe.DataAccess.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<IdentityUser>(options)
{


    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<AppUser> appUsers { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }


}
