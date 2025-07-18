using ShopMe.DataAccess.Context;
using ShopMe.Entities.Models;
using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.RepositoryServices;

internal class ShopingCartRepository(AppDbContext _db) : GenericRepository<ShoppingCart>( _db), IShopingCartRepository
{
}
