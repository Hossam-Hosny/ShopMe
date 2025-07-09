using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopMe.Entities.Models;

namespace ShopMe.DataAccess.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext(options)
{


    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }



}
