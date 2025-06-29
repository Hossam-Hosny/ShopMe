using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopMe.DataAccess.Context;

namespace ShopMe.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDataAccess(this IServiceCollection _services, IConfiguration config)
    {
        _services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("LocalConnectionString"));
        });

    }
}
