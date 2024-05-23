using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DatingApp.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DbContext RepositoryContext { get; set; }

        public RepositoryBase(DbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            RepositoryContext.Database.SetCommandTimeout(200);
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void CreateRange(T[] entities)
        {
            RepositoryContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void UpdateRange(T[] entities)
        {
            RepositoryContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(T[] entity)
        {
            RepositoryContext.Set<T>().RemoveRange(entity);
        }
    }
}
