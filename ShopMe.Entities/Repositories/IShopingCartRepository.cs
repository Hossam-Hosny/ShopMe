using ShopMe.Entities.Models;

namespace ShopMe.Entities.Repositories;

public interface IShopingCartRepository:IGenericRepository<ShoppingCart>
{
    int IncreaseCount(ShoppingCart cart , int count);
    int DencreaseCount(ShoppingCart cart , int count);
}
