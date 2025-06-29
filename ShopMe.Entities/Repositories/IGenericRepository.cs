using System.Linq.Expressions;

namespace ShopMe.Entities.Repositories;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate , string? IncludeWord);
    T GetFirstorDefault(Expression<Func<T, bool>> predicate, string? IncludeWord);
    void Add (T entity);
    void Remove (T  entity);
    void RemoveRange (IEnumerable<T> entities);



}
