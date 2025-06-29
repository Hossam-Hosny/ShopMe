using Microsoft.EntityFrameworkCore;
using ShopMe.DataAccess.Context;
using ShopMe.Entities.Repositories;
using System.Linq.Expressions;

namespace ShopMe.DataAccess.RepositoryServices;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _db;
    private DbSet<T> _dbSet;


    public GenericRepository(AppDbContext db)
    {
        _db = db;
        _dbSet = _db.Set<T>();
    }

    public void Add(T entity)
    {
        _db.Add(entity);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, string? IncludeWord)
    {
        IQueryable<T> query = _dbSet;
        if (predicate !=null)
            query = query.Where(predicate);

        if (IncludeWord != null)
        {
            foreach (var item in IncludeWord.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
            {
               query = query.Include(item);
            }
        }
        return query.ToList();
    }

    public T GetFirstorDefault(Expression<Func<T, bool>> predicate, string? IncludeWord)
    {

        IQueryable<T> query = _dbSet;
        if (predicate != null)
            query = query.Where(predicate);

        if (IncludeWord != null)
        {
            foreach (var item in IncludeWord.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        return query.SingleOrDefault();
    }

    public void Remove(T entity)
    {
        _db.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _db.RemoveRange(entities);
    }
}
