using Microsoft.EntityFrameworkCore;
using ShopMe.Web.Models;

namespace ShopMe.Web.Context;

public class AppDbContext (DbContextOptions<AppDbContext> options):DbContext(options)
{


    public DbSet<Category> Categories { get; set; }



}
