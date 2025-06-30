using ShopMe.Entities.Repositories;

namespace ShopMe.DataAccess.RepositoryServices.UnitOfWork;

public interface IUnitOfWork:IDisposable
{
    ICategoryRepository Category { get; }
    int Complete();

}
