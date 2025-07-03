using ShopMe.DataAccess.Context;
using ShopMe.Entities.Models;
using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.RepositoryServices;

internal class ProductRepository(AppDbContext db) : GenericRepository<Product>(db), IProductRepository
{


    public void Update(Product product)
    {
        var productInDB = db.Products.FirstOrDefault(x => x.Id == product.Id);
        if (productInDB != null)
        {
            productInDB.Name = product.Name;
            productInDB.Description = product.Description;
            productInDB.Price = product.Price;
            productInDB.ImagePath = product.ImagePath;
            productInDB.CategoryId = product.CategoryId;


            
        }

    }
}
