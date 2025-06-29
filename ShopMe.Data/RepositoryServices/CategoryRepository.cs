using ShopMe.DataAccess.Context;
using ShopMe.Entities.Models;
using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.RepositoryServices;

internal class CategoryRepository(AppDbContext db) : GenericRepository<Category>(db), ICategoryRepository
{


    public void Update(Category category)
    {
        var categoryInDB = db.Categories.FirstOrDefault(x => x.Id == category.Id);
        if (categoryInDB != null)
        {
            categoryInDB.Name = category.Name;
            categoryInDB.Description = category.Description;
            
        }

    }
}
