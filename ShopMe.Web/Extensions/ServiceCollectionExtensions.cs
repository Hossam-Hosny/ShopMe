using Microsoft.EntityFrameworkCore;
using ShopMe.Web.Context;

namespace ShopMe.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddWeb(this WebApplicationBuilder builder , IConfiguration config)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("LocalConnectionString"));
        });
    }
}
