using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopMe.DataAccess.Context;
using ShopMe.DataAccess.RepositoryServices;
using ShopMe.DataAccess.RepositoryServices.UnitOfWork;
using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDataAccess(this IServiceCollection _services, IConfiguration config)
    {
        _services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("LocalConnectionString"));
        });

        _services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        _services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
