using ShopMe.Entities.Models;

namespace ShopMe.Entities.Repositories;

public interface ICategoryRepository:IGenericRepository<Category>
{
    void Update (Category category);
}
