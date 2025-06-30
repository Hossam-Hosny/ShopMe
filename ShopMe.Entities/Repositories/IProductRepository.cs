using ShopMe.Entities.Models;

namespace ShopMe.Entities.Repositories;

public interface IProductRepository:IGenericRepository<Product>
{
    void Update (Product category);
}
