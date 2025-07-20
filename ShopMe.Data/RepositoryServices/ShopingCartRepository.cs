using ShopMe.DataAccess.Context;
using ShopMe.Entities.Models;
using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.RepositoryServices;

internal class ShopingCartRepository(AppDbContext _db) : GenericRepository<ShoppingCart>(_db), IShopingCartRepository
{
    public int DencreaseCount(ShoppingCart cart, int count)
    {
        cart.Count -= count;
        return cart.Count;
    }

    public int IncreaseCount(ShoppingCart cart, int count)
    {
        cart.Count += count;
        return cart.Count;
    }
}
