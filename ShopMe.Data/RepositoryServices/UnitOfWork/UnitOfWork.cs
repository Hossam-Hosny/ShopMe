using ShopMe.DataAccess.Context;
using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.RepositoryServices.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    public ICategoryRepository Category { get; private set; }

    public IProductRepository Product { get; private set; }

    public IShopingCartRepository ShopingCart {  get; private set; }

    private readonly AppDbContext _db;

    public UnitOfWork( AppDbContext db)
    {
       
        _db = db?? throw new ArgumentNullException(nameof(db));
        Category = new CategoryRepository(_db);
        Product = new ProductRepository(_db);
        ShopingCart = new ShopingCartRepository(_db);

    }

    public int Complete()
    {
        return _db.SaveChanges();
    }

    public void Dispose()
    {
         _db.Dispose();
    }
}
